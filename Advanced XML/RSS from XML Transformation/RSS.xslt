<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt"
    xmlns:ts="http://library.by/catalog"
    exclude-result-prefixes="msxsl"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="/ts:catalog">
    <xsl:element name="channel">
      <xsl:element name="title">Books</xsl:element>
      <xsl:element name="link">http://library.by/catalog</xsl:element>
      <xsl:element name="description">Library books news</xsl:element>
      <xsl:apply-templates select="*"/>
    </xsl:element>
  </xsl:template>

  <xsl:template match="ts:book">
    <xsl:element name="item">
      <xsl:element name="title">
        <xsl:value-of select="ts:title"/>
      </xsl:element>
      <xsl:element name="description">
        <xsl:value-of select="ts:description"/>
      </xsl:element>
      <xsl:element name="pubDate">
        <xsl:value-of select="ts:registration_date"/>
      </xsl:element>
      <xsl:if test="(ts:isbn) and (ts:genre='Computer')">
        <xsl:element name="link">http://my.safaribooksonline.com/<xsl:value-of select="ts:isbn"/>/</xsl:element>
      </xsl:if>
    </xsl:element>
  </xsl:template>
</xsl:stylesheet>
