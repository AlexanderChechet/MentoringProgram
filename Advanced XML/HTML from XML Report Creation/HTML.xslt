<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"
    xmlns:ts="http://library.by/catalog"
    xmlns:ext="http://epam.com/xslt/ext"
    exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>
  
    <xsl:variable name="datetime">2018-05-07</xsl:variable>
  
    <xsl:template match="ts:catalog">
      <xsl:element name="html">
        <xsl:element name="head">
          <xsl:element name="title">Current genre fonds</xsl:element>
        </xsl:element>
        <xsl:element name="body">
          <xsl:element name ="h1">HTML Report <xsl:value-of select="$datetime"/></xsl:element>
          <xsl:apply-templates select="*"/>
          <xsl:call-template name="genres"/>
        </xsl:element>
      </xsl:element>
    </xsl:template>

    <xsl:template match="ts:book">
      <xsl:value-of select="ext:AddGenre(./ts:genre)"/>
    </xsl:template>

  
    <xsl:template name="genres">
      <xsl:element name="h2">
        <xsl:value-of select="ext:GetGenre()"/>
      </xsl:element>
      <xsl:element name="table">
        <xsl:call-template name="table_header"/>
        <xsl:for-each select="/ts:catalog/ts:book[ts:genre = ext:GetGenre()]">
          <xsl:element name="tr">
            <xsl:element name="td">
              <xsl:value-of select="ts:author"/>
            </xsl:element>
            <xsl:element name="td">
              <xsl:value-of select="ts:title"/>
            </xsl:element>
            <xsl:element name="td">
              <xsl:value-of select="ts:publish_date"/>
            </xsl:element>
            <xsl:element name="td">
              <xsl:value-of select="ts:registration_date"/>
            </xsl:element>
          </xsl:element>
        </xsl:for-each>
      </xsl:element>
      <xsl:if test="ext:MoveNext()">
        <xsl:call-template name="genres"/> 
      </xsl:if>
    </xsl:template>
  
    <xsl:template name="table_header">
      <xsl:element name="tr">
        <xsl:element name="td">Author</xsl:element>
        <xsl:element name="td">Title</xsl:element>
        <xsl:element name="td">Publish date</xsl:element>
        <xsl:element name="td">Registration date</xsl:element>
      </xsl:element>
    </xsl:template>
</xsl:stylesheet>
