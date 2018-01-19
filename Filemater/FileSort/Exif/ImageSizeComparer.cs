/*
 * Copyright (c) 2018 mebiusbox software. All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions
 * are met:
 * 1. Redistributions of source code must retain the above copyright
 *    notice, this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 *    notice, this list of conditions and the following disclaimer in the
 *    documentation and/or other materials provided with the distribution.
 *
 * THIS SOFTWARE IS PROVIDED BY THE AUTHOR AND CONTRIBUTORS ``AS IS'' AND
 * ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED.  IN NO EVENT SHALL THE AUTHOR OR CONTRIBUTORS BE LIABLE
 * FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS
 * OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
 * HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
 * LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
 * OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF
 * SUCH DAMAGE.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Filemater.FileSort.Exif
{
    public class ImageSizeComparer : IComparer<File>
    {
        public int Compare(File x, File y)
        {
            uint w1 = 0;
            uint h1 = 0;
            uint w2 = 0;
            uint h2 = 0;

            if (x.Exif != null)
            {
                if (x.Exif.ExifImageWidth != null)
                {
                    w1 = x.Exif.ExifImageWidth.Value;
                }

                if (x.Exif.ExifImageHeight != null)
                {
                    h1 = x.Exif.ExifImageHeight.Value;
                }
            }

            if (y.Exif != null)
            {
                if (y.Exif.ExifImageWidth != null)
                {
                    w2 = y.Exif.ExifImageWidth.Value;
                }

                if (y.Exif.ExifImageHeight != null)
                {
                    h2 = y.Exif.ExifImageHeight.Value;
                }
            }

            if (w1 == w2)
            {
                return h1.CompareTo(h1);
            }
            else
            {
                return w1.CompareTo(w2);
            }
        }
    }
}
