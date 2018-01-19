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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Filemater.Nodes.Filter
{
    public partial class ExifNodeForm : UserControl
    {
        public Nodes.Filter.ExifNode Node;
        private bool m_init = false;

        public ExifNodeForm(Nodes.Filter.ExifNode node)
        {
            InitializeComponent();
            this.Node = node;
            this.ctrlPriority.Value = this.Node.Priority;
            this.ctrlNumber1.Maximum = Int32.MaxValue;
            this.ctrlNumber2.Maximum = Int32.MaxValue;
            this.ctrlNumber1.Minimum = Int32.MinValue;
            this.ctrlNumber2.Minimum = Int32.MinValue;
            this.ctrlTarget.Items.AddRange(Nodes.Filter.ExifNode.TagItemNameJpTable);
            this.ctrlNumberMethod.Items.AddRange(Nodes.Filter.SizeNode.SizeMethodTypeText);
            this.ctrlTimeMethod.Items.AddRange(Nodes.Filter.TimeNode.TimeMethodTypeText);
            this.ctrlSearchWord.Text = this.Node.Word;
            this.ctrlNumber1.Value = (decimal)this.Node.NumberF1;
            this.ctrlNumber2.Value = (decimal)this.Node.NumberF2;
            this.ctrlNumberMethod.SelectedIndex = (int)this.Node.NumberMethodType;
            this.ctrlTime1.Value = this.Node.Time1;
            this.ctrlTime2.Value = this.Node.Time2;
            this.ctrlTimeMethod.SelectedIndex = (int)this.Node.TimeMethodType;
            this.ctrlTarget.SelectedIndex = (int)this.Node.Target;
            this.m_init = true;
        }

        /// <summary>
        /// 
        /// </summary>
        private void NotifyChange()
        {
            if (this.m_init)
            {
                Global.RaiseEvent(Global.ModifyDocumentEvent);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ResetCurrentMode()
        {
            this.ctrlModeString.Enabled = true;
            this.ctrlModeConstant.Enabled = false;
            this.ctrlConstant.Items.Clear();
            this.ctrlModeNumber.Enabled = false;
            this.ctrlModeDate.Enabled = false;
            this.Node.Mode = Nodes.Filter.ExifNode.TagItemModeTable[(int)this.Node.Target];
            if (this.m_init)
            {
                this.Node.Constant = 0;
            }

            switch (this.Node.Mode)
            {
                case ExifNode.ModeType.STRING:
                    this.ctrlModeString.Enabled = true;
                    this.ctrlModeString.Checked = true;
                    break;

                case ExifNode.ModeType.CONSTANT:
                    this.ctrlModeConstant.Enabled = true;
                    this.ctrlModeConstant.Checked = true;
                    ResetConstant();
                    break;

                case ExifNode.ModeType.NUMBER:
                    this.ctrlModeNumber.Enabled = true;
                    this.ctrlModeNumber.Checked = true;
                    break;

                case ExifNode.ModeType.DATE:
                    this.ctrlModeDate.Enabled = true;
                    this.ctrlModeDate.Checked = true;
                    break;
            }
        }

        #region Text tables

        public static string[] OrientationText = {
            "Top Left",
            "Top Right",
            "Bottom Left",
            "Bottom Right",
            "Left Top",
            "Right Top",
            "Left Bottom",
            "Right Bottom"
        };

        public static string[] ResolutionUnitText = {
            "No Unit",
            "Inch",
            "cm"
        };

        public static string[] YCbCrPositioningText = {
            "Unknown",
            "Centered",
            "Cosited"
        };

        public static string[] ComponentsConfigurationText = {
            "Unknown",
            "RGB",
            "YCbCr"
        };

        public static string[] MeteringModeText = {
            "Unknown",
            "Average",
            "Center Weighted Average",
            "Spot",
            "Multi Spot",
            "Pattern",
            "Partial"
        };

        public static string[] LightSourceText = {
            "Unknown",
            "Daylight",
            "Fluorescent",
            "Tungsten",
            "Flash",
            "Fine weather",
            "Shade",
            "Daylight fluorescent",
            "Day white fluorescent",
            "Cool white fluorescent",
            "White fluorescent",
            "Standard light A",
            "Standard light B",
            "Standard light C",
            "D55",
            "D65",
            "D75",
            "D50",
            "ISO studio tungsten"
        };

        public static int[] LightSourceIndices = {
            0, 1, 2, 3, 4, 9, 10, 11, 12, 13, 14, 15, 17, 18, 19,
            20, 21, 22, 23, 24
        };

        public static string[] ExposureProgramText = {
            "Not defined",
            "Manual",
            "Normal program",
            "Aperture priority",
            "Shutter priority",
            "Creative priority",
            "Action program",
            "Portrait mode",
            "Landscape mode"
        };

        public static string[] SensingMethodText = {
            "Not defiend",
            "One-chip color area sensor",
            "Two-chip color area sensor",
            "Three-chip color area sensor",
            "Color sequential area sensor",
            "Trilinear sensor",
            "Color sequential linear sensor"
        };

        public static string[] ColorSpaceText = {
            "Unknown",
            "sRGB",
            "Uncalibrated"
        };

        public static int[] ColorSpaceIndices = {
            0, 1, 0xffff
        };

        public static string[] FocalPlaneResolutionUnitText = {
            "No unit",
            "Inch",
            "cm"
        };

        #endregion

        /// <summary>
        /// 
        /// </summary>
        private void ResetConstant()
        {
            switch (this.Node.Target)
            {
                case Nodes.Filter.ExifNode.TagItem.Orientation:
                    this.ctrlConstant.Items.AddRange(OrientationText);
                    break;

                case Nodes.Filter.ExifNode.TagItem.ResolutionUnit:
                    this.ctrlConstant.Items.AddRange(ResolutionUnitText);
                    break;

                case Nodes.Filter.ExifNode.TagItem.YCbCrPositioning:
                    this.ctrlConstant.Items.AddRange(YCbCrPositioningText);
                    break;

                case Nodes.Filter.ExifNode.TagItem.ComponentsConfiguration:
                    this.ctrlConstant.Items.AddRange(ComponentsConfigurationText);
                    break;

                case Nodes.Filter.ExifNode.TagItem.MeteringMode:
                    this.ctrlConstant.Items.AddRange(MeteringModeText);
                    break;

                case Nodes.Filter.ExifNode.TagItem.LightSource:
                    this.ctrlConstant.Items.AddRange(LightSourceText);
                    break;

                case Nodes.Filter.ExifNode.TagItem.ExposureProgram:
                    this.ctrlConstant.Items.AddRange(ExposureProgramText);
                    break;

                case Nodes.Filter.ExifNode.TagItem.SensingMethod:
                    this.ctrlConstant.Items.AddRange(SensingMethodText);
                    break;

                case Nodes.Filter.ExifNode.TagItem.ColorSpace:
                    this.ctrlConstant.Items.AddRange(ColorSpaceText);
                    break;

                case Nodes.Filter.ExifNode.TagItem.FocalPlaneResolutionUnit:
                    this.ctrlConstant.Items.AddRange(FocalPlaneResolutionUnitText);
                    break;

                case Nodes.Filter.ExifNode.TagItem.Flash:
                    this.ctrlConstant.Items.AddRange(libpixy.net.Exif.ExifTags.FlashTextTable);
                    break;
            }

            this.ctrlConstant.SelectedIndex = this.Node.Constant;
        }

        private void ctrlTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.Target = (ExifNode.TagItem)this.ctrlTarget.SelectedIndex;
            ResetCurrentMode();
            NotifyChange();
        }

        private void ctrlSearchWord_TextChanged(object sender, EventArgs e)
        {
            this.Node.Word = this.ctrlSearchWord.Text;
            NotifyChange();
        }

        private void ctrlConstant_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.Constant = this.ctrlConstant.SelectedIndex;
            NotifyChange();
        }

        private void ctrlNumber1_ValueChanged(object sender, EventArgs e)
        {
            this.Node.NumberI1 = (int)this.ctrlNumber1.Value;
            this.Node.NumberF1 = (float)this.ctrlNumber1.Value;
            NotifyChange();
        }

        private void ctrlNumber2_ValueChanged(object sender, EventArgs e)
        {
            this.Node.NumberI2 = (int)this.ctrlNumber2.Value;
            this.Node.NumberF2 = (float)this.ctrlNumber2.Value;
            NotifyChange();
        }

        private void ctrlNumberMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.NumberMethodType = (SizeNode.SizeMethodType)this.ctrlNumberMethod.SelectedIndex;
            switch (this.Node.NumberMethodType)
            {
                case SizeNode.SizeMethodType.IN_RANGE:
                case SizeNode.SizeMethodType.OUT_RANGE:
                    this.ctrlNumber2.Enabled = true;
                    break;

                default:
                    this.ctrlNumber2.Enabled = false;
                    break;
            }
            NotifyChange();
        }

        private void ctrlTime1_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Time1 = new DateTime(
                this.ctrlTime1.Value.Year,
                this.ctrlTime1.Value.Month,
                this.ctrlTime1.Value.Day);
            NotifyChange();
        }

        private void ctrlTime2_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Time2 = new DateTime(
                this.ctrlTime2.Value.Year,
                this.ctrlTime2.Value.Month,
                this.ctrlTime2.Value.Day);
            NotifyChange();
        }

        private void ctrlTimeMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Node.TimeMethodType = (TimeNode.TimeMethodType)this.ctrlTimeMethod.SelectedIndex;
            switch (this.Node.TimeMethodType)
            {
                case TimeNode.TimeMethodType.IN_RANGE:
                case TimeNode.TimeMethodType.OUT_RANGE:
                    this.ctrlTime2.Enabled = true;
                    break;

                default:
                    this.ctrlTime2.Enabled = false;
                    break;
            }
            NotifyChange();
        }

        private void ctrlPriority_ValueChanged(object sender, EventArgs e)
        {
            this.Node.Priority = (int)this.ctrlPriority.Value;
            NotifyChange();
        }
    }
}
