using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.IO;

/// <summary>
/// Descripción breve de CRC32
/// </summary>
public class CRC32
{

    private UInt32[] crc32Table;
    private const int BUFFER_SIZE = 1024;

    public UInt32 GetCrc32(System.IO.Stream stream)
    {
        unchecked
        {
            UInt32 crc32Result;
            crc32Result = 0xFFFFFFFF;
            byte[] buffer = new byte[BUFFER_SIZE];
            int readSize = BUFFER_SIZE;

            int count = stream.Read(buffer, 0, readSize);
            while (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    crc32Result = ((crc32Result) >> 8) ^ crc32Table[(buffer[i]) ^ ((crc32Result) & 0x000000FF)];
                }
                count = stream.Read(buffer, 0, readSize);
            }

            return ~crc32Result;
        }
    }

    public CRC32()
    {
        unchecked
        {
            UInt32 dwPolynomial = 0xEDB88320;
            UInt32 i, j;

            crc32Table = new UInt32[256];

            UInt32 dwCrc;
            for (i = 0; i < 256; i++)
            {
                dwCrc = i;
                for (j = 8; j > 0; j--)
                {
                    if ((dwCrc & 1) == 1)
                    {
                        dwCrc = (dwCrc >> 1) ^ dwPolynomial;
                    }
                    else
                    {
                        dwCrc >>= 1;
                    }
                }
                crc32Table[i] = dwCrc;
            }
        }
    }

}