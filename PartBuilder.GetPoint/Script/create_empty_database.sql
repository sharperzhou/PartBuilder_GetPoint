/*
 Navicat Premium Data Transfer

 Source Server         : ISO垫圈
 Source Server Type    : SQLite
 Source Server Version : 3021000
 Source Schema         : main

 Target Server Type    : SQLite
 Target Server Version : 3021000
 File Encoding         : 65001

 Date: 11/06/2019 17:21:58
*/

PRAGMA foreign_keys = false;

-- ----------------------------
-- Table structure for HCCommon_DimStyle
-- ----------------------------
DROP TABLE IF EXISTS "HCCommon_DimStyle";
CREATE TABLE "HCCommon_DimStyle" (
  "DimStyleID" integer DEFAULT 0,
  "DimStyleName" varchar (50) NOT NULL
);

-- ----------------------------
-- Table structure for HCCommon_EntType
-- ----------------------------
DROP TABLE IF EXISTS "HCCommon_EntType";
CREATE TABLE "HCCommon_EntType" (
  "EntType" integer DEFAULT 0,
  "EntName" varchar (150),
  "DisplayName" varchar (50),
  "DisplayPic" blob,
  "TableName" varchar (50),
  "DefaultFlag" integer DEFAULT 0,
  "DefaultStatus" integer DEFAULT 0,
  "DefaultLayer" integer DEFAULT 0,
  "Filter" varchar (255),
  "Description" varchar (255)
);

-- ----------------------------
-- Table structure for HCCommon_Layer
-- ----------------------------
DROP TABLE IF EXISTS "HCCommon_Layer";
CREATE TABLE "HCCommon_Layer" (
  "LayerID" integer DEFAULT 0,
  "LayerName" varchar (50) NOT NULL,
  "ActualLayer" varchar (50) NOT NULL
);

-- ----------------------------
-- Table structure for HCCommon_Pattern
-- ----------------------------
DROP TABLE IF EXISTS "HCCommon_Pattern";
CREATE TABLE "HCCommon_Pattern" (
  "PatternID" integer DEFAULT 0,
  "PatternName" varchar (50) NOT NULL,
  "Description" varchar (255),
  "Picture" blob
);

-- ----------------------------
-- Table structure for HCCommon_Property
-- ----------------------------
DROP TABLE IF EXISTS "HCCommon_Property";
CREATE TABLE "HCCommon_Property" (
  "PropertyID" integer,
  "PropertyName" varchar (50)
);

-- ----------------------------
-- Table structure for HCCommon_TextStyle
-- ----------------------------
DROP TABLE IF EXISTS "HCCommon_TextStyle";
CREATE TABLE "HCCommon_TextStyle" (
  "TextStyleID" integer DEFAULT 0,
  "TextStyleName" varchar (50)
);

-- ----------------------------
-- Table structure for HCDimension_2LAngular
-- ----------------------------
DROP TABLE IF EXISTS "HCDimension_2LAngular";
CREATE TABLE "HCDimension_2LAngular" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtStart1" integer DEFAULT 0,
  "PtEnd1" integer DEFAULT 0,
  "PtStart2" integer DEFAULT 0,
  "PtEnd2" integer DEFAULT 0,
  "PtArc" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCDimension_3PAngular
-- ----------------------------
DROP TABLE IF EXISTS "HCDimension_3PAngular";
CREATE TABLE "HCDimension_3PAngular" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtExt1" integer DEFAULT 0,
  "PtExt2" integer DEFAULT 0,
  "PtVert" integer DEFAULT 0,
  "PtArc" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCDimension_Aligned
-- ----------------------------
DROP TABLE IF EXISTS "HCDimension_Aligned";
CREATE TABLE "HCDimension_Aligned" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtExt1" integer DEFAULT 0,
  "PtExt2" integer DEFAULT 0,
  "PtDim" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCDimension_Diametric
-- ----------------------------
DROP TABLE IF EXISTS "HCDimension_Diametric";
CREATE TABLE "HCDimension_Diametric" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtCenter" integer DEFAULT 0,
  "Radius" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCDimension_Ordinate
-- ----------------------------
DROP TABLE IF EXISTS "HCDimension_Ordinate";
CREATE TABLE "HCDimension_Ordinate" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtDef" integer DEFAULT 0,
  "PtOri" integer DEFAULT 0,
  "PtEnd" integer DEFAULT 0,
  "IsAxisX" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCDimension_Radial
-- ----------------------------
DROP TABLE IF EXISTS "HCDimension_Radial";
CREATE TABLE "HCDimension_Radial" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtCenter" integer DEFAULT 0,
  "Radius" float DEFAULT 0
);

-- ----------------------------
-- Table structure for HCDimension_Rotated
-- ----------------------------
DROP TABLE IF EXISTS "HCDimension_Rotated";
CREATE TABLE "HCDimension_Rotated" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtExt1" integer DEFAULT 0,
  "PtExt2" integer DEFAULT 0,
  "PtDim" integer DEFAULT 0,
  "Direction" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCDimension_Styles
-- ----------------------------
DROP TABLE IF EXISTS "HCDimension_Styles";
CREATE TABLE "HCDimension_Styles" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "DimStyleID" integer DEFAULT 0,
  "DIMTOH" integer DEFAULT 0,
  "DIMTIH" integer DEFAULT 0,
  "IsOblique" integer DEFAULT 0,
  "ObliqueAngle" integer DEFAULT 0,
  "DIMJUST" integer DEFAULT 0,
  "DIMTAD" integer DEFAULT 0,
  "DIMSD1" integer DEFAULT 1,
  "DIMSD2" integer DEFAULT 1,
  "DIMSE1" integer DEFAULT 1,
  "DIMSE2" integer DEFAULT 1
);

-- ----------------------------
-- Table structure for HCDimension_Texts
-- ----------------------------
DROP TABLE IF EXISTS "HCDimension_Texts";
CREATE TABLE "HCDimension_Texts" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtText" integer DEFAULT 0,
  "Content" varchar (50),
  "IsExp" integer DEFAULT 0,
  "IsRotated" integer DEFAULT 0,
  "TextRotation" float DEFAULT 0,
  "IsTolNo" integer DEFAULT 0,
  "TolNumber" varchar (50),
  "IsTolVal" integer DEFAULT 0,
  "TopValue" float DEFAULT 0,
  "BottomValue" float DEFAULT 0,
  "IsFix" integer DEFAULT 0,
  "Suffix" varchar (50),
  "Prefix" varchar (50),
  "TolUnit" varchar (50),
  "IsRect" integer DEFAULT 0,
  "DIMDEC" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCEntity_Arc
-- ----------------------------
DROP TABLE IF EXISTS "HCEntity_Arc";
CREATE TABLE "HCEntity_Arc" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtCenter" integer DEFAULT 0,
  "Radius" integer DEFAULT 0,
  "AngStart" integer DEFAULT 0,
  "AngEnd" integer DEFAULT 0,
  "PtStart" integer DEFAULT 0,
  "PtEnd" integer DEFAULT 0,
  "ArcType" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCEntity_Circle
-- ----------------------------
DROP TABLE IF EXISTS "HCEntity_Circle";
CREATE TABLE "HCEntity_Circle" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtCenter" integer DEFAULT 0,
  "Radius" float DEFAULT 0,
  "PtFirst" integer DEFAULT 0,
  "PtSecond" integer DEFAULT 0,
  "CircleType" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCEntity_Ellipse
-- ----------------------------
DROP TABLE IF EXISTS "HCEntity_Ellipse";
CREATE TABLE "HCEntity_Ellipse" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtCenter" integer NOT NULL DEFAULT 0,
  "RadMajor" integer NOT NULL DEFAULT 0,
  "RadMinor" integer NOT NULL DEFAULT 0,
  "AngStart" integer DEFAULT 1,
  "AngEnd" integer DEFAULT 1,
  "PtMajor" integer NOT NULL DEFAULT 1,
  "PtMinor" integer NOT NULL DEFAULT 1,
  "IsArc" integer NOT NULL DEFAULT 0
);

-- ----------------------------
-- Table structure for HCEntity_Group
-- ----------------------------
DROP TABLE IF EXISTS "HCEntity_Group";
CREATE TABLE "HCEntity_Group" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "EntListID" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCEntity_Hatch
-- ----------------------------
DROP TABLE IF EXISTS "HCEntity_Hatch";
CREATE TABLE "HCEntity_Hatch" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PatternID" integer DEFAULT 0,
  "IsDoubled" integer DEFAULT 1,
  "Scale" float DEFAULT 0,
  "Angle" float DEFAULT 0,
  "EntListCount" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCEntity_Leader
-- ----------------------------
DROP TABLE IF EXISTS "HCEntity_Leader";
CREATE TABLE "HCEntity_Leader" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtListID" integer DEFAULT 0,
  "RefEntity" integer DEFAULT 0,
  "LeaderType" integer DEFAULT 2,
  "Underline" integer DEFAULT 1
);

-- ----------------------------
-- Table structure for HCEntity_Line
-- ----------------------------
DROP TABLE IF EXISTS "HCEntity_Line";
CREATE TABLE "HCEntity_Line" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtStart" integer DEFAULT 0,
  "PtEnd" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCEntity_ListEntity
-- ----------------------------
DROP TABLE IF EXISTS "HCEntity_ListEntity";
CREATE TABLE "HCEntity_ListEntity" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "EntListID" integer DEFAULT 0,
  "RefEntID" integer DEFAULT -1
);

-- ----------------------------
-- Table structure for HCEntity_ListPoint
-- ----------------------------
DROP TABLE IF EXISTS "HCEntity_ListPoint";
CREATE TABLE "HCEntity_ListPoint" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtListID" integer DEFAULT 0,
  "PointID" integer DEFAULT -1,
  "SortPos" integer NOT NULL DEFAULT 0
);

-- ----------------------------
-- Table structure for HCEntity_MText
-- ----------------------------
DROP TABLE IF EXISTS "HCEntity_MText";
CREATE TABLE "HCEntity_MText" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtInsert" integer DEFAULT 0,
  "Content" memo,
  "IsExp" integer DEFAULT 0,
  "IsTolNo" integer DEFAULT 0,
  "TolNumber" varchar (50) DEFAULT '"H7"',
  "IsTolVal" integer DEFAULT 0,
  "TopValue" float DEFAULT 0,
  "BottomValue" float DEFAULT 0,
  "IsFix" integer DEFAULT 0,
  "Suffix" varchar (50),
  "Prefix" varchar (50),
  "TextAngle" integer DEFAULT 0,
  "TextHeight" integer DEFAULT 0,
  "Width" integer DEFAULT 0,
  "SpacingFactor" float DEFAULT 1,
  "TextStyleID" integer DEFAULT 0,
  "TextAlign" integer DEFAULT 1
);

-- ----------------------------
-- Table structure for HCEntity_Polyline
-- ----------------------------
DROP TABLE IF EXISTS "HCEntity_Polyline";
CREATE TABLE "HCEntity_Polyline" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PolylineType" integer NOT NULL DEFAULT 0,
  "PtListID" integer NOT NULL DEFAULT 0,
  "Width" float NOT NULL DEFAULT 0,
  "IsClosed" integer NOT NULL DEFAULT 0
);

-- ----------------------------
-- Table structure for HCEntity_Text
-- ----------------------------
DROP TABLE IF EXISTS "HCEntity_Text";
CREATE TABLE "HCEntity_Text" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "PtInsert" integer NOT NULL DEFAULT 1,
  "Content" varchar (255) NOT NULL,
  "IsExp" integer NOT NULL DEFAULT 0,
  "TextHeight" integer NOT NULL DEFAULT 1,
  "TextAngle" integer NOT NULL DEFAULT 0,
  "ObliqueAngle" float NOT NULL DEFAULT 0,
  "ScaleFactor" float NOT NULL DEFAULT 1,
  "TextStyleID" integer NOT NULL DEFAULT 1
);

-- ----------------------------
-- Table structure for HCPara_EntityDef
-- ----------------------------
DROP TABLE IF EXISTS "HCPara_EntityDef";
CREATE TABLE "HCPara_EntityDef" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "EntName" varchar (50),
  "EntType" integer DEFAULT 0,
  "SortPos" integer DEFAULT 0,
  "Filter" varchar (255) DEFAULT '1',
  "IsAssist" integer DEFAULT 0,
  "IsMatch" integer DEFAULT 0,
  "LayerID" integer DEFAULT 0,
  "Description" varchar (255),
  "NodeID" integer DEFAULT 0,
  "EntFlag" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCPara_EntityTree
-- ----------------------------
DROP TABLE IF EXISTS "HCPara_EntityTree";
CREATE TABLE "HCPara_EntityTree" (
  "PartID" integer DEFAULT 0,
  "NodeID" integer DEFAULT 0,
  "NodeName" varchar (255),
  "ParentID" integer DEFAULT 0,
  "SortPos" integer DEFAULT 0,
  "Reserved" varchar (255)
);

-- ----------------------------
-- Table structure for HCPara_InputData
-- ----------------------------
DROP TABLE IF EXISTS "HCPara_InputData";
CREATE TABLE "HCPara_InputData" (
  "PartID" integer DEFAULT 0,
  "ParaID" integer DEFAULT 0,
  "LineID" integer DEFAULT 0,
  "StrValue" varchar(255),
  "RealValue" float DEFAULT 0,
  "Reserved" varchar(255)
);

-- ----------------------------
-- Table structure for HCPara_InputDef
-- ----------------------------
DROP TABLE IF EXISTS "HCPara_InputDef";
CREATE TABLE "HCPara_InputDef" (
  "PartID" integer DEFAULT 0,
  "ParaID" integer DEFAULT 0,
  "ParaName" varchar (50) NOT NULL,
  "ParaType" integer NOT NULL DEFAULT 0,
  "SortPos" integer NOT NULL DEFAULT 0,
  "IsVisible" integer NOT NULL DEFAULT 1,
  "IsKey" integer DEFAULT 0,
  "StrValue" varchar (255),
  "RealValue" float DEFAULT 0,
  "ParentID" integer DEFAULT 0,
  "Description" varchar (255),
  "Reserved" varchar (255)
);

-- ----------------------------
-- Table structure for HCPara_InputRestrict
-- ----------------------------
DROP TABLE IF EXISTS "HCPara_InputRestrict";
CREATE TABLE "HCPara_InputRestrict" (
  "PartID" integer DEFAULT 0,
  "LineID" integer DEFAULT 0,
  "ParentID" integer DEFAULT 0,
  "ParentRestrictID" integer DEFAULT 0,
  "ParaID" integer DEFAULT 0,
  "RestrictID" integer DEFAULT 0,
  "StrValue" varchar(255),
  "RealValue" float DEFAULT 0,
  "SortPos" integer DEFAULT 0,
  "Reserved" varchar(255)
);

-- ----------------------------
-- Table structure for HCPara_PointDef
-- ----------------------------
DROP TABLE IF EXISTS "HCPara_PointDef";
CREATE TABLE "HCPara_PointDef" (
  "PartID" integer DEFAULT 0,
  "PointID" integer DEFAULT 0,
  "PointName" varchar (150) NOT NULL,
  "PointType" integer DEFAULT 1,
  "XValue" varchar (255) NOT NULL DEFAULT '0',
  "YValue" varchar (255) NOT NULL DEFAULT '0',
  "ZValue" varchar (255) DEFAULT '0',
  "SortPos" integer DEFAULT 0,
  "Description" varchar (255),
  "Reserved" varchar (255),
  "NodeID" integer DEFAULT 0,
  "Expression" varchar (255),
  "CalcOrder" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCPara_PointTree
-- ----------------------------
DROP TABLE IF EXISTS "HCPara_PointTree";
CREATE TABLE "HCPara_PointTree" (
  "PartID" integer DEFAULT 0,
  "NodeID" integer DEFAULT 0,
  "NodeName" varchar (255),
  "ParentID" integer DEFAULT 0,
  "SortPos" integer DEFAULT 0,
  "Reserved" varchar (255)
);

-- ----------------------------
-- Table structure for HCPara_StructDef
-- ----------------------------
DROP TABLE IF EXISTS "HCPara_StructDef";
CREATE TABLE "HCPara_StructDef" (
  "PartID" integer DEFAULT 0,
  "ParaID" integer DEFAULT 0,
  "ParaName" varchar (50),
  "Expression" varchar (255) NOT NULL DEFAULT '0',
  "SortPos" integer DEFAULT 0,
  "IsVisible" integer DEFAULT 1,
  "IsExp" integer NOT NULL DEFAULT 0,
  "Description" varchar (255),
  "Reserved" varchar (255),
  "NodeID" integer DEFAULT 0,
  "CalcOrder" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCPara_StructTree
-- ----------------------------
DROP TABLE IF EXISTS "HCPara_StructTree";
CREATE TABLE "HCPara_StructTree" (
  "PartID" integer DEFAULT 0,
  "NodeID" integer DEFAULT 0,
  "NodeName" varchar (255),
  "ParentID" integer DEFAULT 0,
  "SortPos" integer DEFAULT 0,
  "Reserved" varchar (255)
);

-- ----------------------------
-- Table structure for HCParts
-- ----------------------------
DROP TABLE IF EXISTS "HCParts";
CREATE TABLE "HCParts" (
  "PartID" integer DEFAULT 0,
  "PartName" varchar (150),
  "DictID" integer DEFAULT 0,
  "SortPos" integer DEFAULT 0,
  "PartType" integer DEFAULT 0,
  "PtBase" integer DEFAULT 1,
  "Angle" integer DEFAULT 0,
  "Scale" integer DEFAULT 0,
  "Picture" blob,
  "Reserved1" varchar (255),
  "Reserved2" integer DEFAULT 0,
  "Option" integer DEFAULT 0,
  "IsHide" integer DEFAULT 0,
  "IsReadOnly" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCParts_Directory
-- ----------------------------
DROP TABLE IF EXISTS "HCParts_Directory";
CREATE TABLE "HCParts_Directory" (
  "DictID" integer PRIMARY KEY AUTOINCREMENT,
  "FatherID" integer DEFAULT 0,
  "DictName" varchar (50),
  "SortPos" integer DEFAULT 0,
  "DictType" integer DEFAULT 0,
  "Reserved" varchar (255),
  "IsHide" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCParts_Property
-- ----------------------------
DROP TABLE IF EXISTS "HCParts_Property";
CREATE TABLE "HCParts_Property" (
  "PartID" integer DEFAULT 0,
  "PropertyID" integer DEFAULT 0,
  "Content" varchar (255),
  "IsExp" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCParts_View
-- ----------------------------
DROP TABLE IF EXISTS "HCParts_View";
CREATE TABLE "HCParts_View" (
  "PartID" integer DEFAULT 0,
  "ViewID" integer DEFAULT 0,
  "ViewName" varchar (50),
  "SortPos" integer DEFAULT 0,
  "Description" varchar (255),
  "PtBase" integer DEFAULT 1,
  "Picture" blob,
  "Option" integer DEFAULT 0,
  "Status" integer DEFAULT 1,
  "Reserved" varchar (255)
);

-- ----------------------------
-- Table structure for HCParts_ViewEntities
-- ----------------------------
DROP TABLE IF EXISTS "HCParts_ViewEntities";
CREATE TABLE "HCParts_ViewEntities" (
  "PartID" integer DEFAULT 0,
  "ViewID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCSubPart_Define
-- ----------------------------
DROP TABLE IF EXISTS "HCSubPart_Define";
CREATE TABLE "HCSubPart_Define" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "RefPartID" integer DEFAULT 0,
  "PtBase" integer DEFAULT 0,
  "Angle" integer DEFAULT 0,
  "Scale" integer DEFAULT 0,
  "IsUseKey" integer DEFAULT 0,
  "Option" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCSubPart_Para
-- ----------------------------
DROP TABLE IF EXISTS "HCSubPart_Para";
CREATE TABLE "HCSubPart_Para" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "SubInitParaID" integer DEFAULT 0,
  "ParentStructParaID" integer DEFAULT 0,
  "Reserved" varchar (255)
);

-- ----------------------------
-- Table structure for HCSubPart_View
-- ----------------------------
DROP TABLE IF EXISTS "HCSubPart_View";
CREATE TABLE "HCSubPart_View" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "SubPartViewID" integer DEFAULT 0,
  "Reserved" varchar (255),
  "PtBase" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCTrans_Mirror
-- ----------------------------
DROP TABLE IF EXISTS "HCTrans_Mirror";
CREATE TABLE "HCTrans_Mirror" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "EntListID" integer DEFAULT 0,
  "PtFrom" integer DEFAULT 0,
  "PtTo" integer DEFAULT 0,
  "IsCopy" integer DEFAULT 0,
  "Option" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCTrans_Move
-- ----------------------------
DROP TABLE IF EXISTS "HCTrans_Move";
CREATE TABLE "HCTrans_Move" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "EntListID" integer DEFAULT 0,
  "PtFrom" integer DEFAULT 0,
  "PtTo" integer DEFAULT 1,
  "IsCopy" integer DEFAULT 0,
  "Option" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCTrans_PolarArray
-- ----------------------------
DROP TABLE IF EXISTS "HCTrans_PolarArray";
CREATE TABLE "HCTrans_PolarArray" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "EntListID" integer DEFAULT 0,
  "PtBase" integer DEFAULT 0,
  "PtCenter" integer DEFAULT 0,
  "Count" integer DEFAULT 0,
  "Angle" integer DEFAULT 0,
  "IsRotate" integer DEFAULT 0,
  "Option" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCTrans_RectArray
-- ----------------------------
DROP TABLE IF EXISTS "HCTrans_RectArray";
CREATE TABLE "HCTrans_RectArray" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "EntListID" integer DEFAULT 0,
  "RowCount" integer DEFAULT 0,
  "ColCount" integer DEFAULT 0,
  "RowSpace" integer DEFAULT 0,
  "ColSpace" integer DEFAULT 0,
  "Angle" integer DEFAULT 0,
  "Option" integer DEFAULT 0
);

-- ----------------------------
-- Table structure for HCTrans_Rotate
-- ----------------------------
DROP TABLE IF EXISTS "HCTrans_Rotate";
CREATE TABLE "HCTrans_Rotate" (
  "PartID" integer DEFAULT 0,
  "EntityID" integer DEFAULT 0,
  "EntListID" integer DEFAULT 0,
  "PtBase" integer DEFAULT 0,
  "Angle" integer DEFAULT 0,
  "IsCopy" integer DEFAULT 0,
  "Option" integer DEFAULT 0
);

-- ----------------------------
-- Indexes structure for table HCCommon_DimStyle
-- ----------------------------
CREATE UNIQUE INDEX "DimStyleNameID"
ON "HCCommon_DimStyle" (
  "DimStyleID" ASC
);

-- ----------------------------
-- Indexes structure for table HCCommon_EntType
-- ----------------------------
CREATE INDEX "EntityTypeID"
ON "HCCommon_EntType" (
  "EntType" ASC
);

-- ----------------------------
-- Indexes structure for table HCCommon_Layer
-- ----------------------------
CREATE INDEX "LayerID"
ON "HCCommon_Layer" (
  "LayerID" ASC
);

-- ----------------------------
-- Indexes structure for table HCCommon_Pattern
-- ----------------------------
CREATE INDEX "PatternID"
ON "HCCommon_Pattern" (
  "PatternID" ASC
);

-- ----------------------------
-- Indexes structure for table HCCommon_TextStyle
-- ----------------------------
CREATE INDEX "TextStyleNameID"
ON "HCCommon_TextStyle" (
  "TextStyleID" ASC
);

-- ----------------------------
-- Indexes structure for table HCDimension_2LAngular
-- ----------------------------
CREATE INDEX "EntityID"
ON "HCDimension_2LAngular" (
  "EntityID" ASC
);
CREATE INDEX "THLINESPartID"
ON "HCDimension_2LAngular" (
  "PartID" ASC
);

-- ----------------------------
-- Indexes structure for table HCEntity_Circle
-- ----------------------------
CREATE INDEX "PartID"
ON "HCEntity_Circle" (
  "PartID" ASC
);

-- ----------------------------
-- Indexes structure for table HCEntity_Group
-- ----------------------------
CREATE INDEX "EntityListID"
ON "HCEntity_Group" (
  "EntListID" ASC
);

-- ----------------------------
-- Indexes structure for table HCEntity_Leader
-- ----------------------------
CREATE INDEX "PointListID"
ON "HCEntity_Leader" (
  "PtListID" ASC
);

-- ----------------------------
-- Indexes structure for table HCPara_EntityDef
-- ----------------------------
CREATE INDEX "THPartEntitiesEntityTypeID"
ON "HCPara_EntityDef" (
  "EntType" ASC
);

-- ----------------------------
-- Indexes structure for table HCPara_EntityTree
-- ----------------------------
CREATE INDEX "FatherNodeID"
ON "HCPara_EntityTree" (
  "ParentID" ASC
);
CREATE INDEX "NodeID"
ON "HCPara_EntityTree" (
  "NodeID" ASC
);

-- ----------------------------
-- Indexes structure for table HCPara_InputData
-- ----------------------------
CREATE INDEX "ParaID"
ON "HCPara_InputData" (
  "ParaID" ASC
);
CREATE INDEX "RowID"
ON "HCPara_InputData" (
  "LineID" ASC
);

-- ----------------------------
-- Indexes structure for table HCPara_InputDef
-- ----------------------------
CREATE INDEX "FatherParaID"
ON "HCPara_InputDef" (
  "ParentID" ASC
);

-- ----------------------------
-- Indexes structure for table HCPara_InputRestrict
-- ----------------------------
CREATE INDEX "Fa_RestrictValueID"
ON "HCPara_InputRestrict" (
  "ParentRestrictID" ASC
);
CREATE INDEX "RestrictValueID"
ON "HCPara_InputRestrict" (
  "RestrictID" ASC
);

-- ----------------------------
-- Indexes structure for table HCPara_PointDef
-- ----------------------------
CREATE INDEX "CalculateSortID"
ON "HCPara_PointDef" (
  "CalcOrder" ASC
);
CREATE INDEX "PointID"
ON "HCPara_PointDef" (
  "PointID" ASC
);

-- ----------------------------
-- Indexes structure for table HCPara_StructDef
-- ----------------------------
CREATE INDEX "StructureID"
ON "HCPara_StructDef" (
  "ParaID" ASC
);

-- ----------------------------
-- Indexes structure for table HCParts
-- ----------------------------
CREATE INDEX "FatherID"
ON "HCParts" (
  "DictID" ASC
);

-- ----------------------------
-- Auto increment value for HCParts_Directory
-- ----------------------------
UPDATE "sqlite_sequence" SET seq = 1 WHERE name = 'HCParts_Directory';

-- ----------------------------
-- Indexes structure for table HCParts_Directory
-- ----------------------------
CREATE INDEX "ID"
ON "HCParts_Directory" (
  "DictID" ASC
);

-- ----------------------------
-- Indexes structure for table HCParts_Property
-- ----------------------------
CREATE INDEX "THPartPrptysPropertyID"
ON "HCParts_Property" (
  "PropertyID" ASC
);

-- ----------------------------
-- Indexes structure for table HCParts_View
-- ----------------------------
CREATE INDEX "PartViewID"
ON "HCParts_View" (
  "ViewID" ASC
);

-- ----------------------------
-- Indexes structure for table HCSubPart_Define
-- ----------------------------
CREATE INDEX "RefPartID"
ON "HCSubPart_Define" (
  "RefPartID" ASC
);

-- ----------------------------
-- Indexes structure for table HCSubPart_View
-- ----------------------------
CREATE INDEX "BasePoint"
ON "HCSubPart_View" (
  "PtBase" ASC
);
CREATE INDEX "SelViewID"
ON "HCSubPart_View" (
  "SubPartViewID" ASC
);

-- ----------------------------
-- Indexes structure for table HCTrans_Mirror
-- ----------------------------
CREATE INDEX "WhichSelect"
ON "HCTrans_Mirror" (
  "EntListID" ASC
);

-- ----------------------------
-- Records of HCCommon_DimStyle
-- ----------------------------
INSERT INTO "HCCommon_DimStyle" VALUES (1, 'HC_GBDIM');
INSERT INTO "HCCommon_DimStyle" VALUES (2, 'HC_GBDIM1');
INSERT INTO "HCCommon_DimStyle" VALUES (3, 'STANDARD');

-- ----------------------------
-- Records of HCCommon_EntType
-- ----------------------------
INSERT INTO "HCCommon_EntType" VALUES (1, 'Line', '直线', NULL, 'HCEntity_Line', 1, 4, 0, 1, '直线');
INSERT INTO "HCCommon_EntType" VALUES (2, 'Circle', '圆', NULL, 'HCEntity_Circle', 1, 4, 0, 1, '圆');
INSERT INTO "HCCommon_EntType" VALUES (3, 'Arc', '圆弧', NULL, 'HCEntity_Arc', 1, 4, 0, 1, '圆弧');
INSERT INTO "HCCommon_EntType" VALUES (4, 'Ellipse', '椭圆', NULL, 'HCEntity_Ellipse', 1, 4, 0, 1, '椭圆');
INSERT INTO "HCCommon_EntType" VALUES (5, 'Polyline', '多段线', NULL, 'HCEntity_Polyline', 1, 4, 0, 1, '2d多义线');
INSERT INTO "HCCommon_EntType" VALUES (7, 'Text', '单行文字', NULL, 'HCEntity_Text', 3, 4, 2, 1, '单行文字');
INSERT INTO "HCCommon_EntType" VALUES (8, 'Mtext', '多行文字', NULL, 'HCEntity_Mtext', 3, 4, 2, 1, '多行文字');
INSERT INTO "HCCommon_EntType" VALUES (9, 'Attribute', '以后扩展用字段', NULL, '以后扩展用字段', 0, 4, 0, 1, '以后扩展用字段');
INSERT INTO "HCCommon_EntType" VALUES (10, 'BlockDefine', '以后扩展用字段', NULL, '以后扩展用字段', 0, 4, 0, 1, '以后扩展用字段');
INSERT INTO "HCCommon_EntType" VALUES (11, 'Insert', '块插入', NULL, '以后扩展用字段', 3, 4, 0, 1, '块插入');
INSERT INTO "HCCommon_EntType" VALUES (12, 'Group', '选择集', NULL, 'HCEntity_Group', 1, 6, 0, 1, '选择集');
INSERT INTO "HCCommon_EntType" VALUES (13, 'Hatch', '剖面线', NULL, 'HCEntity_Hatch', 2, 4, 1, 1, '剖面线');
INSERT INTO "HCCommon_EntType" VALUES (14, 'DimLeader', '引线标注', NULL, 'HCEntity_Leader', 2, 4, 3, 1, '引线标注');
INSERT INTO "HCCommon_EntType" VALUES (15, 'DimRotated', '旋转标注', NULL, 'HCDimension_Rotated', 3, 4, 3, 1, '旋转标注');
INSERT INTO "HCCommon_EntType" VALUES (16, 'DimAligned', '对齐标注', NULL, 'HCDimension_Aligned', 2, 4, 3, 1, '对齐标注');
INSERT INTO "HCCommon_EntType" VALUES (17, 'DimDiametric', '直径标注', NULL, 'HCDimension_Diametric', 2, 4, 3, 1, '直径标注');
INSERT INTO "HCCommon_EntType" VALUES (18, 'DimRadial', '半径标注', NULL, 'HCDimension_Radial', 2, 4, 3, 1, '半径标注');
INSERT INTO "HCCommon_EntType" VALUES (19, 'Dim3PointAngular', '三点角度标注', NULL, 'HCDimension_3PAngular', 2, 4, 3, 1, '三点角度标注');
INSERT INTO "HCCommon_EntType" VALUES (20, 'Dim2LineAngular', '两线角度标注', NULL, 'HCDimension_2LAngular', 2, 4, 3, 1, '两线角度标注');
INSERT INTO "HCCommon_EntType" VALUES (21, 'DimOrdinate', '坐标标注', NULL, 'HCDimension_Ordinate', 2, 4, 3, 1, '坐标标注');
INSERT INTO "HCCommon_EntType" VALUES (22, 'Move', '移动变换', NULL, 'HCTrans_Move', 1, 6, 0, 1, '移动变换');
INSERT INTO "HCCommon_EntType" VALUES (23, 'PolarArray', '环形阵列', NULL, 'HCTrans_PolarArray', 1, 6, 0, 1, '环形阵列');
INSERT INTO "HCCommon_EntType" VALUES (24, 'RectArray', '矩形阵列', NULL, 'HCTrans_RectArray', 1, 6, 0, 1, '矩形阵列');
INSERT INTO "HCCommon_EntType" VALUES (25, 'Rotate', '旋转变换', NULL, 'HCTrans_Rotate', 1, 6, 0, 1, '旋转变换');
INSERT INTO "HCCommon_EntType" VALUES (26, 'Mirror', '镜像变换', NULL, 'HCTrans_Mirror', 1, 6, 0, 1, '镜像变换');
INSERT INTO "HCCommon_EntType" VALUES (27, 'BasePart', '子零件', NULL, 'HCSubPart_Define', 1, 6, 0, 1, '子零件');

-- ----------------------------
-- Records of HCCommon_Layer
-- ----------------------------
INSERT INTO "HCCommon_Layer" VALUES (0, '轮廓实线', '1轮廓实线层');
INSERT INTO "HCCommon_Layer" VALUES (1, '细线', '2细线层');
INSERT INTO "HCCommon_Layer" VALUES (2, '中心线', '3中心线层');
INSERT INTO "HCCommon_Layer" VALUES (3, '虚线', '4虚线层');
INSERT INTO "HCCommon_Layer" VALUES (4, '剖面线', '5剖面线层');
INSERT INTO "HCCommon_Layer" VALUES (5, '文字', '6文字层');
INSERT INTO "HCCommon_Layer" VALUES (6, '标注', '7标注层');
INSERT INTO "HCCommon_Layer" VALUES (7, '符号标注', '8符号标注层');
INSERT INTO "HCCommon_Layer" VALUES (8, '双点划线', '9双点划线层');
INSERT INTO "HCCommon_Layer" VALUES (9, '轮廓虚线', '轮廓虚线层');
INSERT INTO "HCCommon_Layer" VALUES (10, '图框', '图框层');
INSERT INTO "HCCommon_Layer" VALUES (11, '消隐', '消隐层');
INSERT INTO "HCCommon_Layer" VALUES (12, '自定义1', '用户自定义1');
INSERT INTO "HCCommon_Layer" VALUES (13, '自定义2', '用户自定义2');
INSERT INTO "HCCommon_Layer" VALUES (14, '自定义3', '用户自定义3');

-- ----------------------------
-- Records of HCCommon_Pattern
-- ----------------------------
INSERT INTO "HCCommon_Pattern" VALUES (1, 'ANSI31', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (2, 'ANSI32', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (3, 'ANSI33', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (4, 'ANSI34', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (5, 'ANSI35', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (6, 'ANSI36', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (7, 'ANSI37', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (8, 'ANSI38', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (9, 'SOLID', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (10, 'ANGLE', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (11, 'BOX', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (12, 'BRASS', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (13, 'BRICK', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (14, 'BRSTONE', NULL, NULL);
INSERT INTO "HCCommon_Pattern" VALUES (15, 'CLAY', NULL, NULL);

-- ----------------------------
-- Records of HCCommon_Property
-- ----------------------------
INSERT INTO "HCCommon_Property" VALUES (0, '代号');
INSERT INTO "HCCommon_Property" VALUES (1, '名称');
INSERT INTO "HCCommon_Property" VALUES (2, '重量');
INSERT INTO "HCCommon_Property" VALUES (3, '材料');
INSERT INTO "HCCommon_Property" VALUES (4, '标注信息');
INSERT INTO "HCCommon_Property" VALUES (5, '备注');
INSERT INTO "HCCommon_Property" VALUES (6, '技术要求');
INSERT INTO "HCCommon_Property" VALUES (7, '其他信息');
INSERT INTO "HCCommon_Property" VALUES (8, '关键字');

-- ----------------------------
-- Records of HCCommon_TextStyle
-- ----------------------------
INSERT INTO "HCCommon_TextStyle" VALUES (1, 'HC_TEXTSTYLE');
INSERT INTO "HCCommon_TextStyle" VALUES (2, 'HC_TEXTSTYLE1');
INSERT INTO "HCCommon_TextStyle" VALUES (3, 'STANDARD');
INSERT INTO "HCCommon_TextStyle" VALUES (4, 'HC_GBDIM');

PRAGMA foreign_keys = true;
