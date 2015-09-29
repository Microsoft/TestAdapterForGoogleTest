﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using GoogleTestAdapter.Helpers;

namespace GoogleTestAdapter.Dia
{

    [StructLayout(LayoutKind.Sequential)]
    // ReSharper disable once InconsistentNaming
    struct LOADED_IMAGE
    {
        public IntPtr ModuleName;
        public IntPtr hFile;
        public IntPtr MappedAddress;
        public IntPtr FileHeader;
        public IntPtr LastRvaSection;
        public uint NumbOfSections;
        public IntPtr FirstRvaSection;
        public uint charachteristics;
        public ushort systemImage;
        public ushort dosImage;
        public ushort readOnly;
        public ushort version;
        public IntPtr links_1;
        public IntPtr links_2;
        public uint sizeOfImage;
        public IntPtr links_3;
        public IntPtr links_4;
        public IntPtr links_5;
    }

    [StructLayout(LayoutKind.Explicit)]
    // ReSharper disable once InconsistentNaming
    struct IMAGE_IMPORT_DESCRIPTOR
    {
        [FieldOffset(0)]
        public uint Characteristics;
        [FieldOffset(0)]
        public uint OriginalFirstThunk;

        [FieldOffset(4)]
        public uint TimeDateStamp;
        [FieldOffset(8)]
        public uint ForwarderChain;
        [FieldOffset(12)]
        public uint Name;
        [FieldOffset(16)]
        public uint FirstThunk;
    }

    enum NameSearchOptions : uint
    {
        NsNone = 0x0u,
        NsfCaseSensitive = 0x1u,
        NsfCaseInsensitive = 0x2u,
        NsfFNameExt = 0x4u,
        NsfRegularExpression = 0x8u,
        NsfUndecoratedName = 0x10u
    }

    class NativeSourceFileLocation
    {
        public string Symbol;
        public uint AddressSection;
        public uint AddressOffset;
        public uint Length;
    }

    unsafe internal static class NativeMethods
    {
        [DllImport("imageHlp.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
        private static extern bool MapAndLoad(string imageName, string dllPath, LOADED_IMAGE* loadedImage, bool dotDll, bool readOnly);

        [DllImport("imageHlp.dll", CallingConvention = CallingConvention.Winapi)]
        private static extern bool UnMapAndLoad(ref LOADED_IMAGE loadedImage);

        [DllImport("dbghelp.dll", CallingConvention = CallingConvention.Winapi)]
        private static extern IMAGE_IMPORT_DESCRIPTOR* ImageDirectoryEntryToData(IntPtr pBase, byte mappedAsImage, ushort directoryEntry, uint* size);

        [DllImport("dbghelp.dll", CallingConvention = CallingConvention.Winapi)]
        private static extern IntPtr ImageRvaToVa(IntPtr pNtHeaders, IntPtr pBase, uint rva, IntPtr pLastRvaSection);

        internal static void ReleaseCom(object obj)
        {
            Marshal.FinalReleaseComObject(obj);
        }


        internal class ImportsParser
        {
            private LOADED_IMAGE _loadedImage = new LOADED_IMAGE();

            internal List<string> Imports { get; } = new List<string>();

            internal ImportsParser(string executable, TestEnvironment testEnvironment)
            {
                fixed (LOADED_IMAGE* fixedLoadedImage = &_loadedImage)
                {
                    if (MapAndLoad(executable, null, fixedLoadedImage, true, true))
                    {
                        uint size = 0u;
                        IMAGE_IMPORT_DESCRIPTOR* directoryEntryPtr = ImageDirectoryEntryToData(fixedLoadedImage->MappedAddress, 0, 1, &size);
                        IMAGE_IMPORT_DESCRIPTOR directoryEntry = *directoryEntryPtr;
                        while (directoryEntry.OriginalFirstThunk != 0u)
                        {
                            Imports.Add(GetString(directoryEntry.Name));
                            directoryEntryPtr++;
                            directoryEntry = *directoryEntryPtr;
                        }
                        if (!UnMapAndLoad(ref _loadedImage))
                        {
                            testEnvironment.LogError("UnMapAndLoad failed!");
                        }
                    }
                }
            }

            private string GetString(uint name)
            {
                IntPtr stringPtr = ImageRvaToVa(_loadedImage.FileHeader, _loadedImage.MappedAddress, name, IntPtr.Zero);
                return Marshal.PtrToStringAnsi(stringPtr);
            }

        }

    }

}