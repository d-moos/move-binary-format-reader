﻿// This software is released under the BSD License.
// See LICENSE file for details.

using System;
using System.IO;

 namespace MoveBinaryReader
{
    /// <summary>
    /// Single-file utility to read and write integers in the LEB128 (7-bit little endian base-128) format.
    /// See https://en.wikipedia.org/wiki/LEB128 for details.
    /// </summary>
    public static class LEB128
    {
        private const long SIGN_EXTEND_MASK = -1L;
        private const int INT64_BITSIZE = (sizeof(long) * 8);


        public static long ReadLEB128Signed (this Stream stream) => ReadLEB128Signed(stream, out _);

        public static long ReadLEB128Signed (this Stream stream, out int bytes) {
            bytes = 0;

            long value = 0;
            int shift = 0;
            bool more = true, signBitSet = false;

            while(more) {
                var next = stream.ReadByte();
                if (next < 0) { throw new InvalidOperationException("Unexpected end of stream"); }

                byte b = (byte)next;
                bytes += 1;

                more = (b & 0x80) != 0; // extract msb
                signBitSet = (b & 0x40) != 0; // sign bit is the msb of a 7-bit byte, so 0x40

                long chunk = b & 0x7fL; // extract lower 7 bits
                value |= chunk << shift;
                shift += 7;
            };

            // extend the sign of shorter negative numbers
            if (shift < INT64_BITSIZE && signBitSet) { value |= SIGN_EXTEND_MASK << shift; }

            return value;
        }

        public static ulong ReadLEB128Unsigned (this Stream stream) => ReadLEB128Unsigned(stream, out _);

        public static ulong ReadLEB128Unsigned (this Stream stream, out int bytes) {
            bytes = 0;

            ulong value = 0;
            int shift = 0;
            bool more = true;

            while (more) {
                var next = stream.ReadByte();
                if (next < 0) { throw new InvalidOperationException("Unexpected end of stream"); }

                byte b = (byte)next;
                bytes += 1;

                more = (b & 0x80) != 0;   // extract msb
                ulong chunk = b & 0x7fUL; // extract lower 7 bits
                value |= chunk << shift;
                shift += 7;
            }

            return value;
        }

    }
}
