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
using System.Windows.Forms;
using System.Xml;

namespace Filemater.Nodes.Filter
{
    public class ExifNode : IFilterNode
    {
        public enum ModeType
        {
            STRING = 0,
            CONSTANT,
            NUMBER,
            DATE
        }

        public static string[] ModeTypeTextEn = {
            "string",
            "constant",
            "number",
            "date"
        };

        public enum TagItem
        {
            Make = 0,
            Model,
            ImageDescription,
            Orientation,
            XResolution,
            YResolution,
            ResolutionUnit,
            Software,
            DateTime,
            Artist,
            WhitePoint,
            PrimaryChromaticities,
            YCbCrCoefficients,
            YCbCrPositioning,
            ReferenceBlackWhite,
            Copyright,
            //ExifIFDPointer,
            ExposureTime,
            FNumber,
            ExposureProgram,
            ISOSpeedRatings,
            ExifVersion,
            DateTimeOriginal,
            DateTimeDigitized,
            ComponentsConfiguration,
            CompressedBitsPerPixel,
            ShutterSpeedValue,
            ApertureValue,
            BrightnessValue,
            ExposureBiasValue,
            MaxApertureValue,
            SubjectDistance,
            MeteringMode,
            LightSource,
            Flash,
            FocalLength,
            //MakerNote,
            UserComment,
            SubsecTime,
            SubsecTimeOriginal,
            SubsecTimeDigitized,
            FlashPixVersion,
            ColorSpace,
            ExifImageWidth,
            ExifImageHeight,
            RelatedSoundFile,
            //InteroperabilityIFDPointer,
            FocalPlaneXResolution,
            FocalPlaneYResolution,
            FocalPlaneResolutionUnit,
            ExposureIndex,
            SensingMethod,
            FileSource,
            SceneType,
            //CFAPattern,
        };

        public static string[] TagItemNameTable = {
            #region Data
            "Make",
            "Model",
            "ImageDescription",
            "Orientation",
            "XResolution",
            "YResolution",
            "ResolutionUnit",
            "Software",
            "DateTime",
            "Artist",
            "WhitePoint",
            "PrimaryChromaticities",
            "YCbCrCoefficients",
            "YCbCrPositioning",
            "ReferenceBlackWhite",
            "Copyright",
            //"ExifIFDPointer",
            "ExposureTime",
            "FNumber",
            "ExposureProgram",
            "ISOSpeedRatings",
            "ExifVersion",
            "DateTimeOriginal",
            "DateTimeDigitized",
            "ComponentsConfiguration",
            "CompressedBitsPerPixel",
            "ShutterSpeedValue",
            "ApertureValue",
            "BrightnessValue",
            "ExposureBiasValue",
            "MaxApertureValue",
            "SubjectDistance",
            "MeteringMode",
            "LightSource",
            "Flash",
            "FocalLength",
            //"MakerNote",
            "UserComment",
            "SubsecTime",
            "SubsecTimeOriginal",
            "SubsecTimeDigitized",
            "FlashPixVersion",
            "ColorSpace",
            "ExifImageWidth",
            "ExifImageHeight",
            "RelatedSoundFile",
            //"InteroperabilityIFDPointer",
            "FocalPlaneXResolution",
            "FocalPlaneYResolution",
            "FocalPlaneResolutionUnit",
            "ExposureIndex",
            "SensingMethod",
            "FileSource",
            "SceneType",
            //"CFAPattern",
            #endregion
        };

        public static string[] TagItemNameJpTable = {
            #region Data
            "画像入力機器のメーカー名",/* Make */
            "画像入力機器のモデル名",/* Model */
            "画像タイトル",/* ImageDescription */
            "画像方向",/* Orientation */
            "画像の幅の解像度",/* XResolution */
            "画像の高さの解像度",/* YResolution */
            "画像の幅と高さの解像度の単位",/* ResolutionUnit */
            "使用ソフトウェア名",/* Software */
            "ファイル変更日時",/* DateTime */
            "アーティスト",/* Artist */
            "参照白色点の色度座標値",/* WhitePoint */
            "原色の色度座標値",/* PrimaryChromaticities */
            "色変換マトリクス係数",/* YCbCrCoefficients */
            "YCC の画素構成 (Y と C の位置)",/* YCbCrPositioning */
            "参照黒色点値と参照白色点値",/* ReferenceBlackWhite */
            "撮影著作権者/編集著作権者",/* Copyright */
            //"Exif タグ",/* ExifIFDPointer */
            "露出時間",/* ExposureTime */
            "F値",/* FNumber */
            "露出プログラム",/* ExposureProgram */
            "ISO スピードレート",/* ISOSpeedRatings */
            "Exif バージョン",/* ExifVersion */
            "原画像データの生成日時",/* DateTimeOriginal */
            "デジタルデータの生成日時",/* DateTimeDigitized */
            "各コンポーネントの意味",/* ComponentsConfiguration */
            "画像圧縮モード",/* CompressedBitsPerPixel */
            "シャッタースピード",/* ShutterSpeedValue */
            "絞り値",/* ApertureValue */
            "輝度値",/* BrightnessValue */
            "露出補正値",/* ExposureBiasValue */
            "レンズ最小 F 値",/* MaxApertureValue */
            "被写体距離",/* SubjectDistance */
            "測光方式",/* MeteringMode */
            "光源",/* LightSource */
            "フラッシュ",/* Flash */
            "レンズ焦点距離",/* FocalLength */
            //"メーカーノート",/* MakerNote */
            "ユーザーコメント",/* UserComment */
            "Date Time のサブセック",/* SubsecTime */
            "Date Time Original のサブセック",/* SubsecTimeOriginal */
            "Date Time Digitized のサブセック",/* SubsecTimeDigitized */
            "対応フラッシュピックスバージョン",/* FlashPixVersion */
            "色空間情報",/* ColorSpace */
            "画像の幅",/* ExifImageWidth */
            "画像の高さ",/* ExifImageHeight */
            "関連音声ファイル",/* RelatedSoundFile */
            //"互換性 IFD へのポインタ",/* InteroperabilityIFDPointer */
            "焦点面の幅の解像度",/* FocalPlaneXResolution */
            "焦点面の高さの解像度",/* FocalPlaneYResolution */
            "焦点面解像度単位",/* FocalPlaneResolutionUnit */
            "露出インデックス",/* ExposureIndex */
            "センサー方式",/* SensingMethod */
            "ファイルソース",/* FileSource */
            "シーンタイプ",/* SceneType */
            //"CFA パターン",/* CFAPattern */
#endregion
        };

        public static ModeType[] TagItemModeTable = {
            #region Data
            ModeType.STRING, /* Make */
            ModeType.STRING, /* Model */
            ModeType.STRING, /* ImageDescription */
            ModeType.CONSTANT, /* Orientation */
            ModeType.NUMBER, /* XResolution */
            ModeType.NUMBER, /* YResolution */
            ModeType.CONSTANT, /* ResolutionUnit */
            ModeType.STRING, /* Software */
            ModeType.DATE, /* DateTime */
            ModeType.STRING, /* Artist */
            ModeType.NUMBER, /* WhitePoint */
            ModeType.NUMBER, /* PrimaryChromaticities */
            ModeType.NUMBER, /* YCbCrCoefficients */
            ModeType.CONSTANT, /* YCbCrPositioning */
            ModeType.NUMBER, /* ReferenceBlackWhite */
            ModeType.STRING, /* Copyright */
            //ModeType.NUMBER, /* ExifIFDPointer */
            ModeType.NUMBER, /* ExposureTime */
            ModeType.NUMBER, /* FNumber */
            ModeType.CONSTANT, /* ExposureProgram */
            ModeType.NUMBER, /* ISOSpeedRatings */
            ModeType.STRING, /* ExifVersion */
            ModeType.DATE, /* DateTimeOriginal */
            ModeType.DATE, /* DateTimeDigitized */
            ModeType.CONSTANT, /* ComponentsConfiguration */
            ModeType.NUMBER, /* CompressedBitsPerPixel */
            ModeType.NUMBER, /* ShutterSpeedValue */
            ModeType.NUMBER, /* ApertureValue */
            ModeType.NUMBER, /* BrightnessValue */
            ModeType.NUMBER, /* ExposureBiasValue */
            ModeType.NUMBER, /* MaxApertureValue */
            ModeType.NUMBER, /* SubjectDistance */
            ModeType.CONSTANT, /* MeteringMode */
            ModeType.CONSTANT, /* LightSource */
            ModeType.CONSTANT, /* Flash */
            ModeType.NUMBER, /* FocalLength */
            //ModeType.STRING, /* MakerNote */
            ModeType.STRING, /* UserComment */
            ModeType.DATE, /* SubsecTime */
            ModeType.DATE, /* SubsecTimeOriginal */
            ModeType.DATE, /* SubsecTimeDigitized */
            ModeType.STRING, /* FlashPixVersion */
            ModeType.CONSTANT, /* ColorSpace */
            ModeType.NUMBER, /* ExifImageWidth */
            ModeType.NUMBER, /* ExifImageHeight */
            ModeType.STRING, /* RelatedSoundFile */
            //ModeType.NUMBER, /* InteroperabilityIFDPointer */
            ModeType.NUMBER, /* FocalPlaneXResolution */
            ModeType.NUMBER, /* FocalPlaneYResolution */
            ModeType.CONSTANT, /* FocalPlaneResolutionUnit */
            ModeType.NUMBER, /* ExposureIndex */
            ModeType.CONSTANT, /* SensingMethod */
            ModeType.STRING, /* FileSource */
            ModeType.STRING, /* SceneType */
            //ModeType.STRING /* CFAPattern */
#endregion
        };

        public TagItem Target = TagItem.Make;
        public ModeType Mode = ModeType.STRING;
        public string Word = "";
        public int Constant = 0;
        public int NumberI1 = 0;
        public int NumberI2 = 0;
        public float NumberF1 = 0.0f;
        public float NumberF2 = 0.0f;
        public Nodes.Filter.SizeNode.SizeMethodType NumberMethodType = SizeNode.SizeMethodType.LESS;
        public DateTime Time1 = DateTime.Now;
        public DateTime Time2 = DateTime.Now;
        public Nodes.Filter.TimeNode.TimeMethodType TimeMethodType = TimeNode.TimeMethodType.BEFORE;

        private string m_workWord;
        private int m_workConstant;
        private Util.NumberChecker.ILongValueMethod m_workLongValueMethod = null;
        private Util.NumberChecker.IFloatValueMethod m_workFloatValueMethod = null;
        private Nodes.Filter.TimeNode.ITimeMethod m_workTimeValueMethod = null;

        /// <summary>
        /// 
        /// </summary>
        public ExifNode()
        {
            this.Text = "Exif";
        }

        #region override

        public override Control Property()
        {
            return new ExifNodeForm(this);
        }

        public override void Exec()
        {
            m_workLongValueMethod = null;
            m_workFloatValueMethod = null;
            m_workTimeValueMethod = null;

            Preprocess();

            if (Process(this.Input))
            {
                Dispatch(0, this.Input);
            }
            else
            {
                Dispatch(1, this.Input);
            }
        }

        #endregion

        #region Process

        /// <summary>
        /// 
        /// </summary>
        private void Preprocess()
        {
            switch (this.Mode)
            {
                case ModeType.STRING:
                    m_workWord = this.Word.ToLower();
                    break;

                case ModeType.CONSTANT:
                    if (this.Target == TagItem.LightSource)
                    {
                        m_workConstant = ExifNodeForm.LightSourceIndices[this.Constant];
                    }
                    else if (this.Target == TagItem.ColorSpace)
                    {
                        m_workConstant = ExifNodeForm.ColorSpaceIndices[this.Constant];
                    }
                    else if (this.Target == TagItem.Flash)
                    {
                        m_workConstant = libpixy.net.Exif.ExifTags.FlashHexTable[this.Constant];
                    }
                    else if (this.Target == TagItem.Orientation ||
                             this.Target == TagItem.ResolutionUnit ||
                             this.Target == TagItem.FocalPlaneResolutionUnit)
                    {
                        m_workConstant = this.Constant + 1;
                    }
                    else
                    {
                        m_workConstant = this.Constant;
                    }
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool Process(File file)
        {
            libpixy.net.Exif.ExifTags exif = file.Exif;
            if (exif == null)
            {
                return false;
            }

            switch (this.Mode)
            {
                case ModeType.STRING:
                    return ProcessString(file, exif);

                case ModeType.CONSTANT:
                    return ProcessConstant(file, exif);

                case ModeType.NUMBER:
                    return ProcessNumber(file, exif);

                case ModeType.DATE:
                    return ProcessDate(file, exif);
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="exif"></param>
        /// <returns></returns>
        private bool ProcessString(File file, libpixy.net.Exif.ExifTags exif)
        {
            string str = "";
            switch (this.Target)
            {
                case TagItem.Make: /* ModeType.STRING: */
                    if (exif.Make != null) str = exif.Make.Value;
                    break;

                case TagItem.Model: /* ModeType.STRING: */
                    if (exif.Model != null) str = exif.Model.Value;
                    break;

                case TagItem.ImageDescription: /* ModeType.STRING: */
                    if (exif.ImageDescription != null) str = exif.ImageDescription.Value;
                    break;

                case TagItem.Orientation: /* ModeType.CONSTANT */
                    if (exif.Orientation != null) str = exif.OrientationAsText();
                    break;

                case TagItem.XResolution: /* ModeType.NUMBER */
                    if (exif.XResolution != null) str = exif.XResolutionAsText();
                    break;

                case TagItem.YResolution: /* ModeType.NUMBER */
                    if (exif.YResolution != null) str = exif.YResolutionAsText();
                    break;

                case TagItem.ResolutionUnit: /* ModeType.CONSTANT */
                    if (exif.ResolutionUnit != null) str = exif.ResolutionUnitAsText();
                    break;

                case TagItem.Software: /* ModeType.STRING: */
                    if (exif.Software != null) str = exif.Software.Value;
                    break;

                case TagItem.DateTime: /* ModeType.DATE */
                    if (exif.DateTime != null) str = exif.DateTime.Value;
                    break;

                case TagItem.Artist: /* ModeType.STRING */
                    if (exif.Artist != null) str = exif.Artist.Value;
                    break;

                case TagItem.WhitePoint: /* ModeType.NUMBER */
                    if (exif.WhitePoint != null) str = exif.WhitePointAsText();
                    break;

                case TagItem.PrimaryChromaticities: /* ModeType.NUMBER */
                    if (exif.PrimaryChromaticities != null) str = exif.PrimaryChromaticitiesAsText();
                    break;

                case TagItem.YCbCrCoefficients: /* ModeType.NUMBER */
                    if (exif.YCbCrCoefficients != null) str = exif.YCbCrCoefficientsAsText();
                    break;

                case TagItem.YCbCrPositioning: /* ModeType.CONSTANT */
                    if (exif.YCbCrPositioning != null) str = exif.YCbCrPositioningAsText();
                    break;

                case TagItem.ReferenceBlackWhite: /* ModeType.NUMBER */
                    if (exif.ReferenceBlackWhite != null) str = exif.ReferenceBlackWhiteAsText();
                    break;

                case TagItem.Copyright: /* ModeType.STRING: */
                    if (exif.Copyright != null) str = exif.Copyright.Value;
                    break;

                case TagItem.ExposureTime: /* ModeType.NUMBER */
                    if (exif.ExposureTime != null) str = exif.ExposureTimeAsText();
                    break;

                case TagItem.FNumber: /* ModeType.NUMBER */
                    if (exif.FNumber != null) str = exif.FNumberAsText();
                    break;

                case TagItem.ExposureProgram: /* ModeType.CONSTANT */
                    if (exif.ExposureProgram != null) str = exif.ExposureProgramAsText();
                    break;

                case TagItem.ISOSpeedRatings: /* ModeType.NUMBER */
                    if (exif.ISOSpeedRatings != null) str = exif.ISOSpeedRatingsAsText();
                    break;

                case TagItem.ExifVersion: /* ModeType.STRING: */
                    if (exif.ExifVersion != null) str = exif.ExifVersion.Value;
                    break;

                case TagItem.DateTimeOriginal: /* ModeType.DATE */
                    if (exif.DateTimeOriginal != null) str = exif.DateTimeOriginal.Value;
                    break;

                case TagItem.DateTimeDigitized: /* ModeType.DATE */
                    if (exif.DateTimeDigitized != null) str = exif.DateTimeDigitized.Value;
                    break;

                case TagItem.ComponentsConfiguration: /* ModeType.CONSTANT */
                    if (exif.ComponentsConfiguration != null) str = exif.ComponentsConfigurationAsText();
                    break;

                case TagItem.CompressedBitsPerPixel: /* ModeType.NUMBER */
                    if (exif.CompressedBitsPerPixel != null) str = exif.CompressedBitsPerPixelAsText();
                    break;

                case TagItem.ShutterSpeedValue: /* ModeType.NUMBER */
                    if (exif.ShutterSpeedValue != null) str = exif.ShutterSpeedValueAsText();
                    break;

                case TagItem.ApertureValue: /* ModeType.NUMBER */
                    if (exif.ApertureValue != null) str = exif.ApertureValueAsText();
                    break;
                    
                case TagItem.BrightnessValue: /* ModeType.NUMBER */
                    if (exif.BrightnessValue != null) str = exif.BrightnessValueAsText();
                    break;

                case TagItem.ExposureBiasValue: /* ModeType.NUMBER */
                    if (exif.ExposureBiasValue != null) str = exif.ExposureBiasValueAsText();
                    break;

                case TagItem.MaxApertureValue: /* ModeType.NUMBER */
                    if (exif.MaxApertureValue != null) str = exif.MaxApertureValueAsText();
                    break;

                case TagItem.SubjectDistance: /* ModeType.NUMBER */
                    if (exif.SubjectDistance != null) str = exif.SubjectDistanceAsText();
                    break;

                case TagItem.MeteringMode: /* ModeType.CONSTANT */
                    if (exif.MeteringMode != null) str = exif.MeteringModeAsText();
                    break;

                case TagItem.LightSource: /* ModeType.CONSTANT */
                    if (exif.LightSource != null) str = exif.LightSourceAsText();
                    break;

                case TagItem.Flash: /* ModeType.CONSTANT */
                    if (exif.Flash != null) str = exif.FlashAsText();
                    break;

                case TagItem.FocalLength: /* ModeType.NUMBER */
                    if (exif.FocalLength != null) str = exif.FocalLengthAsText();
                    break;

                //case TagItem.MakerNote: /* ModeType.STRING: */
                    //if (exif.MakerNote != null) str = exif.MakerNote.Value;
                    //break;

                case TagItem.UserComment: /* ModeType.STRING: */
                    if (exif.UserComment != null) str = exif.UserComment.Value;
                    break;

                case TagItem.SubsecTime: /* ModeType.DATE */
                    if (exif.SubsecTime != null) str = exif.SubsecTime.Value;
                    break;

                case TagItem.SubsecTimeOriginal: /* ModeType.DATE */
                    if (exif.SubsecTimeOriginal != null) str = exif.SubsecTimeOriginal.Value;
                    break;

                case TagItem.SubsecTimeDigitized: /* ModeType.DATE */
                    if (exif.SubsecTimeDigitized != null) str = exif.SubsecTimeDigitized.Value;
                    break;

                case TagItem.FlashPixVersion: /* ModeType.STRING: */
                    if (exif.FlashPixVersion != null) str = exif.FlashPixVersion.Value;
                    break;

                case TagItem.ColorSpace: /* ModeType.CONSTANT */
                    if (exif.ColorSpace != null) str = exif.ColorSpaceAsText();
                    break;

                case TagItem.ExifImageWidth: /* ModeType.NUMBER */
                    if (exif.ExifImageWidth != null) str = exif.ExifImageWidthAsText();
                    break;

                case TagItem.ExifImageHeight: /* ModeType.NUMBER */
                    if (exif.ExifImageHeight != null) str = exif.ExifImageHeightAsText();
                    break;

                case TagItem.RelatedSoundFile: /* ModeType.STRING: */
                    if (exif.RelatedSoundFile != null) str = exif.RelatedSoundFile.Value;
                    break;

                case TagItem.FocalPlaneXResolution: /* ModeType.NUMBER */
                    if (exif.FocalPlaneXResolution != null) str = exif.FocalPlaneXResolutionAsText();
                    break;

                case TagItem.FocalPlaneYResolution: /* ModeType.NUMBER */
                    if (exif.FocalPlaneYResolution != null) str = exif.FocalPlaneYResolutionAsText();
                    break;

                case TagItem.FocalPlaneResolutionUnit: /* ModeType.CONSTANT */
                    if (exif.FocalPlaneResolutionUnit != null) str = exif.FocalPlaneResolutionUnitAsText();
                    break;

                case TagItem.ExposureIndex: /* ModeType.NUMBER */
                    if (exif.ExposureIndex != null) str = exif.ExposureIndexAsText();
                    break;

                case TagItem.SensingMethod: /* ModeType.CONSTANT */
                    if (exif.SensingMethod != null) str = exif.SensingMethodAsText();
                    break;

                case TagItem.FileSource: /* ModeType.STRING: */
                    if (exif.FileSource != null) str = exif.FileSourceAsText();
                    break;

                case TagItem.SceneType: /* ModeType.STRING: */
                    if (exif.SceneType != null) str = exif.SceneTypeAsText();
                    break;

                //case TagItem.CFAPattern: /* ModeType.STRING: */
                    //if (exif.CFAPattern != null) str = exif.CFAPattern.Value;
                    //break;
            }

            str = str.ToLower();
            if (str.IndexOf(m_workWord) >= 0)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="exif"></param>
        /// <returns></returns>
        private bool ProcessConstant(File file, libpixy.net.Exif.ExifTags exif)
        {
            int value = -1;
            switch (this.Target)
            {
                case TagItem.Orientation: /* ModeType.CONSTANT: */
                    if (exif.Orientation != null) value = (int)exif.Orientation.Value;
                    break;

                case TagItem.ResolutionUnit: /* ModeType.CONSTANT: */
                    if (exif.ResolutionUnit != null) value = (int)exif.ResolutionUnit.Value;
                    break;

                case TagItem.YCbCrPositioning: /* ModeType.CONSTANT: */
                    if (exif.YCbCrPositioning != null) value = (int)exif.YCbCrPositioning.Value;
                    break;

                case TagItem.ExposureProgram: /* ModeType.CONSTANT: */
                    if (exif.ExposureProgram != null) value = (int)exif.ExposureProgram.Value;
                    break;

                case TagItem.ComponentsConfiguration: /* ModeType.CONSTANT: */
                    if (exif.ComponentsConfiguration != null) value = (int)exif.ComponentsConfiguration.Value;
                    break;

                case TagItem.MeteringMode: /* ModeType.CONSTANT: */
                    if (exif.MeteringMode != null) value = (int)exif.MeteringMode.Value;
                    break;

                case TagItem.LightSource: /* ModeType.CONSTANT: */
                    if (exif.LightSource != null) value = (int)exif.LightSource.Value;
                    break;

                case TagItem.Flash: /* ModeType.CONSTANT: */
                    if (exif.Flash != null) value = libpixy.net.Exif.ExifTags.GetFlashBits(exif.Flash.Value);
                    break;

                case TagItem.ColorSpace: /* ModeType.CONSTANT: */
                    if (exif.ColorSpace != null) value = (int)exif.ColorSpace.Value;
                    break;

                case TagItem.FocalPlaneResolutionUnit: /* ModeType.CONSTANT: */
                    if (exif.FocalPlaneResolutionUnit != null) value = (int)exif.FocalPlaneResolutionUnit.Value;
                    break;

                case TagItem.SensingMethod: /* ModeType.CONSTANT: */
                    if (exif.SensingMethod != null) value = (int)exif.SensingMethod.Value;
                    break;
            }

            if (m_workConstant == value)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="exif"></param>
        /// <returns></returns>
        private bool ProcessNumber(File file, libpixy.net.Exif.ExifTags exif)
        {
            List<libpixy.net.Exif.Tag.Rational> values = new List<libpixy.net.Exif.Tag.Rational>();
            bool useFloat = false;
            uint valueI = 0;
            bool useValueI = false;

            switch (this.Target)
            {
                case TagItem.XResolution: /* ModeType.NUMBER: */
                    if (exif.XResolution != null) values.Add(exif.XResolution.Value);
                    break;

                case TagItem.YResolution: /* ModeType.NUMBER: */
                    if (exif.YResolution != null) values.Add(exif.YResolution.Value);
                    break;

                case TagItem.WhitePoint: /* ModeType.NUMBER: */
                    if (exif.WhitePoint != null)
                    {
                        values.AddRange(exif.WhitePoint.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.PrimaryChromaticities: /* ModeType.NUMBER: */
                    if (exif.PrimaryChromaticities != null)
                    {
                        values.AddRange(exif.PrimaryChromaticities.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.YCbCrCoefficients: /* ModeType.NUMBER: */
                    if (exif.YCbCrCoefficients != null)
                    {
                        values.AddRange(exif.YCbCrCoefficients.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.ReferenceBlackWhite: /* ModeType.NUMBER: */
                    if (exif.ReferenceBlackWhite != null)
                    {
                        values.AddRange(exif.ReferenceBlackWhite.Value);
                    }
                    break;

#if false
                case TagItem.ExifIFDPointer: /* ModeType.NUMBER: */
                    if (exif.ExifIFDPointer != null)
                    {
                        valueI = exif.ExifIFDPointer.Value;
                        useValueI = true;
                    }
                    break;
#endif

                case TagItem.ExposureTime: /* ModeType.NUMBER: */
                    if (exif.ExposureTime != null)
                    {
                        values.Add(exif.ExposureTime.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.FNumber: /* ModeType.NUMBER: */
                    if (exif.FNumber != null)
                    {
                        values.Add(exif.FNumber.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.ISOSpeedRatings: /* ModeType.NUMBER: */
                    if (exif.ISOSpeedRatings != null)
                    {
                        valueI = exif.ISOSpeedRatings.Value;
                        useValueI = true;
                    }
                    break;

                case TagItem.CompressedBitsPerPixel: /* ModeType.NUMBER: */
                    if (exif.CompressedBitsPerPixel != null)
                    {
                        values.Add(exif.CompressedBitsPerPixel.Value);
                    }
                    break;

                case TagItem.ShutterSpeedValue: /* ModeType.NUMBER: */
                    if (exif.ShutterSpeedValue != null)
                    {
                        values.Add(exif.ShutterSpeedValue.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.ApertureValue: /* ModeType.NUMBER: */
                    if (exif.ApertureValue != null)
                    {
                        values.Add(exif.ApertureValue.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.BrightnessValue: /* ModeType.NUMBER: */
                    if (exif.BrightnessValue != null)
                    {
                        values.Add(exif.BrightnessValue.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.ExposureBiasValue: /* ModeType.NUMBER: */
                    if (exif.ExposureBiasValue != null)
                    {
                        values.Add(exif.ExposureBiasValue.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.MaxApertureValue: /* ModeType.NUMBER: */
                    if (exif.MaxApertureValue != null)
                    {
                        values.Add(exif.MaxApertureValue.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.SubjectDistance: /* ModeType.NUMBER: */
                    if (exif.SubjectDistance != null)
                    {
                        values.Add(exif.SubjectDistance.Value);
                    }
                    break;

                case TagItem.FocalLength: /* ModeType.NUMBER: */
                    if (exif.FocalLength != null)
                    {
                        values.Add(exif.FocalLength.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.ExifImageWidth: /* ModeType.NUMBER: */
                    if (exif.ExifImageWidth != null)
                    {
                        valueI = exif.ExifImageWidth.Value;
                        useValueI = true;
                    }
                    break;

                case TagItem.ExifImageHeight: /* ModeType.NUMBER: */
                    if (exif.ExifImageHeight != null)
                    {
                        valueI = exif.ExifImageHeight.Value;
                        useValueI = true;
                    }
                    break;

#if false
                case TagItem.InteroperabilityIFDPointer: /* ModeType.NUMBER: */
                    if (exif.InteroperabilityIFDPointer != null)
                    {
                        valueI = exif.InteroperabilityIFDPointer.Value;
                        useValueI = true;
                    }
                    break;
#endif

                case TagItem.FocalPlaneXResolution: /* ModeType.NUMBER: */
                    if (exif.FocalPlaneXResolution != null)
                    {
                        values.Add(exif.FocalPlaneXResolution.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.FocalPlaneYResolution: /* ModeType.NUMBER: */
                    if (exif.FocalPlaneYResolution != null)
                    {
                        values.Add(exif.FocalPlaneYResolution.Value);
                        useFloat = true;
                    }
                    break;

                case TagItem.ExposureIndex: /* ModeType.NUMBER: */
                    if (exif.ExposureIndex != null)
                    {
                        values.Add(exif.ExposureIndex.Value);
                    }
                    break;
            }

            if (useFloat)
            {
                foreach (libpixy.net.Exif.Tag.Rational value in values)
                {
                    if (EvalFloatRational(value))
                    {
                        return true;
                    }
                }
            }
            else
            {
                if (useValueI)
                {
                    return EvalLong((long)valueI);
                }
                else
                {
                    foreach (libpixy.net.Exif.Tag.Rational value in values)
                    {
                        if (EvalLongRational(value))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool EvalFloatRational(libpixy.net.Exif.Tag.Rational value)
        {
            if (m_workFloatValueMethod == null)
            {
                m_workFloatValueMethod = Util.NumberChecker.CreateFloatValueMethod(
                    (Util.NumberChecker.MethodType)this.NumberMethodType);
            }

            if (m_workFloatValueMethod == null)
            {
                return false;
            }

            if (value.Denom == 0)
            {
                return false;
            }

            return m_workFloatValueMethod.Eval(
                (float)value.Num / (float)value.Denom,
                this.NumberF1, this.NumberF2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool EvalLongRational(libpixy.net.Exif.Tag.Rational value)
        {
            if (m_workLongValueMethod == null)
            {
                m_workLongValueMethod = Util.NumberChecker.CreateLongValueMethod(
                    (Util.NumberChecker.MethodType)this.NumberMethodType);
            }

            if (m_workLongValueMethod == null)
            {
                return false;
            }

            if (value.Denom == 0)
            {
                return false;
            }

            return m_workLongValueMethod.Eval(
                value.Num / value.Denom,
                this.NumberI1, this.NumberI2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool EvalLong(long value)
        {
            if (m_workLongValueMethod == null)
            {
                m_workLongValueMethod = Util.NumberChecker.CreateLongValueMethod(
                    (Util.NumberChecker.MethodType)this.NumberMethodType);
            }

            if (m_workLongValueMethod == null)
            {
                return false;
            }

            return m_workLongValueMethod.Eval(value, this.NumberI1, this.NumberI2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="exif"></param>
        /// <returns></returns>
        private bool ProcessDate(File file, libpixy.net.Exif.ExifTags exif)
        {
            libpixy.net.Exif.ExifTags.Param<DateTime> date = null;
            
            switch (this.Target)
            {
                case TagItem.DateTime: /* ModeType.DATE: */
                    date = exif.GetDateTime();
                    break;

                case TagItem.DateTimeOriginal: /* ModeType.DATE: */
                    date = exif.GetDateTimeOriginal();
                    break;

                case TagItem.DateTimeDigitized: /* ModeType.DATE: */
                    date = exif.GetDateTimeDigitized();
                    break;

                case TagItem.SubsecTime: /* ModeType.DATE: */
                    date = exif.GetSubsecTime();
                    break;

                case TagItem.SubsecTimeOriginal: /* ModeType.DATE: */
                    date = exif.GetSubsecTimeOriginal();
                    break;

                case TagItem.SubsecTimeDigitized: /* ModeType.DATE: */
                    date = exif.GetSubsecTimeDigitized();
                    break;
            }

            if (date == null)
            {
                return false;
            }

            if (m_workTimeValueMethod == null)
            {
                m_workTimeValueMethod = Nodes.Filter.TimeNode.CreateMethod(
                    (TimeNode.TimeMethodType)this.TimeMethodType);
            }

            if (m_workTimeValueMethod == null)
            {
                return false;
            }

            return m_workTimeValueMethod.Eval(
                new DateTime(date.Value.Year, date.Value.Month, date.Value.Day),
                this.Time1, this.Time2);
        }

        #endregion

        #region Serialize

        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        public override void Serialize(System.Xml.XmlWriter w)
        {
            base.Serialize(w);

            w.WriteElementString("Target", TagItemNameTable[(int)this.Target]);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Mode", ModeTypeTextEn[(int)this.Mode]);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("PatternValue", this.Word);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("ConstantValue", this.Constant.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("NumberIValue1", this.NumberI1.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("NumberFValue1", this.NumberF1.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("NumberIValue2", this.NumberI2.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("NumberFValue2", this.NumberF2.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("NumberMethod", SizeNode.SizeMethodTypeTextEn[(int)this.NumberMethodType]);
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Time1", this.Time1.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("Time2", this.Time2.ToString());
            w.WriteWhitespace("\r\n");
            w.WriteElementString("TimeMethod", TimeNode.TimeMethodTypeTextEn[(int)this.TimeMethodType]);
            w.WriteWhitespace("\r\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public override void Deserialize(System.Xml.XmlReader r)
        {
            base.Deserialize(r);
            this.Target = (TagItem)libpixy.net.Utils.ArrayUtils.IndexOf(TagItemNameTable, r.ReadElementString("Target"));
            this.Mode = (ModeType)libpixy.net.Utils.ArrayUtils.IndexOf(ModeTypeTextEn, r.ReadElementString("Mode"));
            this.Word = r.ReadElementString("PatternValue");
            this.Constant = Int32.Parse(r.ReadElementString("ConstantValue"));
            this.NumberI1 = Int32.Parse(r.ReadElementString("NumberIValue1"));
            this.NumberF1 = float.Parse(r.ReadElementString("NumberFValue1"));
            this.NumberI2 = Int32.Parse(r.ReadElementString("NumberIValue2"));
            this.NumberF2 = float.Parse(r.ReadElementString("NumberFValue2"));
            this.NumberMethodType = (SizeNode.SizeMethodType)libpixy.net.Utils.ArrayUtils.IndexOf(
                        SizeNode.SizeMethodTypeTextEn, r.ReadElementString("NumberMethod"));
            this.Time1 = DateTime.Parse(r.ReadElementString("Time1"));
            this.Time2 = DateTime.Parse(r.ReadElementString("Time2"));
            this.TimeMethodType = (TimeNode.TimeMethodType)libpixy.net.Utils.ArrayUtils.IndexOf(
                        TimeNode.TimeMethodTypeTextEn, r.ReadElementString("TimeMethod"));
        }

        #endregion
    }
}
