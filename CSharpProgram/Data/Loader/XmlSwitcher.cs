/**
 * @file	XMLSwitcher.cs
 * @class	XMLSwitcher
 * @description
 *          XML 파일을 찾은 후 XmlDocument 클래스를 반환해주는 클래스
 */

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

public class XMLSwitcher
{
    /*
    [윈도우 에디터]
    Application.dataPath			: 프로젝트디렉토리/Assets
    Application.persistentDataPath	: 사용자디렉토리/AppData/LocalLow/회사이름/프로덕트이름			[파일 읽기 쓰기 가능]
    Application.streamingAssetsPath	: 프로젝트디렉토리/Assets/StreamingAssets						[파일 읽기 쓰기 가능]
    Application.temporaryCachePath	: %LocalAppData%/Local/Temp/Temp/회사이름/프로덕트이름
	
    [윈도우 응용프로그램]
    Application.dataPath			: 실행파일/실행파일_Data
    Application.persistentDataPath	: 사용자디렉토리/AppData/LocalLow/회사이름/프로덕트이름			[파일 읽기 쓰기 가능]
    Application.streamingAssetsPath	: 실행파일/실행파일_Data/StreamingAssets						[파일 읽기 쓰기 가능]
	
    [맥 에디터]
    Application.dataPath			: 프로젝트디렉토리/Assets
    Application.persistentDataPath	: 사용자디렉토리/Library/Caches/unity.회사이름.프로덕트이름		[파일 읽기 쓰기 가능]
    Application.streamingAssetsPath	: 프로젝트디렉토리/Assets/StreamingAssets						[파일 읽기 쓰기 가능]
	
    [맥 응용프로그램]
    Application.dataPath			: 실행파일.app/Contents
    Application.persistentDataPath	: 사용자디렉토리/Library/Caches/unity.회사이름.프로덕트이름		[파일 읽기 쓰기 가능]
    Application.streamingAssetsPath	: 실행파일.app/Contents/Data/StreamingAssets					[파일 읽기 쓰기 가능]
	
    [웹 플랫폼]				* 웹에서는 명시적인 파일 쓰기 불가능. 애셋번들로 해야함
    Application.dataPath			: unity3d파일이 있는 폴더
    Application.persistentDataPath	: /
    Application.streamingAssetsPath	: 값 없음.
    Application.temporaryCachePath	: %LocalAppData%/Local/Temp/Temp/회사이름/프로덕트이름

    [안드로이드 Internal]
    Application.dataPath			: /data/app/번들이름-번호.apk
    Application.persistentDataPath	: /data/data/번들이름/files/									[파일 읽기 쓰기 가능]
    Application.streamingAssetsPath	: jar:file:///data/app/번들이름.apk!/assets						[파일이 아닌 WWW로 읽기 가능]
    Application.temporaryCachePath	: /data/data/번들이름/cache
	
    [안드로이드 External]	* sdcard
    Application.dataPath			: /data/app/번들이름-번호.apk
    Application.persistentDataPath	: /mnt/sdcard/Android/data/번들이름/files						[파일 읽기 쓰기 가능]
    Application.streamingAssetsPath	: jar:file:///data/app/번들이름.apk!/assets						[파일이 아닌 WWW로 읽기 가능]
    Application.temporaryCachePath	: /mnt/sdcard/Android/data/번들이름/cache

    [iOS]
    Application.dataPath			: /var/mobile/Applications/프로그램ID/앱이름.app/Data
    Application.persistentDataPath	: /var/mobile/Applications/프로그램ID/Documents					[파일 읽기 쓰기 가능]
    Application.streamingAssetsPath	: /var/mobile/Applications/프로그램ID/앱이름.app/Data/Raw		[파일 읽기 가능, 쓰기 불가능]
    Application.temporaryCachePath	: /var/mobile/Applications/프로그램ID/Library/Caches
    */

    public static string ASSET_PATH = "..\\..\\Data\\Xml\\";
    public const short kLoadCountReader = 2000;

    public static IEnumerator AsyncFileLoading(string strFilePath, System.Action<MemoryStream> result = null)
    {
        //Debug.Log("[AsyncFileLoading] " + strFilePath);
        //Debugger.Log(strFilePath);
        MemoryStream memStream = null;
#if SERVER || TOOL 
        {
            //CDefine.CommonLog("1__" + strFilePath); //chamto test
            memStream = new MemoryStream(File.ReadAllBytes(strFilePath));
        }

#elif UNITY_IPHONE || UNITY_ANDROID || UNITY_EDITOR
		{
			WWW wwwUrl = new WWW(strFilePath);
			//yield return wwwUrl; //유니티 내부에서 WWW 객체가 파일을 다 받을떄까지 코루틴을 수행한다.
			//yield return null; //유니티 외에도 WWW가 동작해야 하므로 파일을 다 받을때까지 기다리는 처리를 직접한다.

			while ( !wwwUrl.isDone )
			{   //WWW 다운로드 진행중
				if ( wwwUrl.error != null )
				{
					Debugger.LogError("error : " + wwwUrl.error.ToString());
					yield break;
				}
				yield return null;
			}

			memStream = new MemoryStream(wwwUrl.bytes);
		}
#endif

        if (null != result)
        {   //무명람다 콜백함수를 이용한 반환값 처리
            result(memStream);
        }
        //CDefine.CommonLog("AsyncLoading complete");
        yield return memStream;
    }

	/// <summary>
	/// Server용 XML 파일 정보 읽는 함수
	/// XmlDocument Xmldoc = XMLSwitcher.GetServerXML()
	/// </summary>
	/// <param name="xmlFileName">.xml 이 없는 상태로 넘겨준다.</param>
	/// <returns></returns>
    public static XmlDocument GetXMLDocument(string xmlFileName)
	{
		string path = string.Format("{0}{1}.xml", ASSET_PATH, xmlFileName);
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.Load(path);
		return xmlDocument;
	}
	public static XmlReader GetXMLReader(string xmlFileName)
	{
		string path = string.Format("{0}{1}.xml", ASSET_PATH, xmlFileName);
		XmlReader xmlDocument = XmlReader.Create(path);
		return xmlDocument;
	}

    private static string CheckFileName(string xmlFileName)
    {
        if (xmlFileName.Contains(".xml"))
        {
            Debugger.LogWarning("Have '.xml'  : " + xmlFileName);
            xmlFileName = xmlFileName.Replace(".xml", "");
        }
        if (xmlFileName.Contains(ASSET_PATH) )
        {
            Debugger.LogWarning("Have 'Data\\Xml\\'  : " + xmlFileName);
            xmlFileName = xmlFileName.Replace(ASSET_PATH, "");
        }
        return xmlFileName;
    }

	public static void LoadFromFile(string strFileName, IXmlParse parseOne, bool isEnd = true)
	{
		CTimeProfiler.Begin(string.Format("{0}.Load", strFileName));

        XmlReader Xmldoc = GetXMLReader(strFileName);

		while ( Xmldoc.Read() )
		{
			if ( IsReadContinue(Xmldoc) )
			{
				parseOne.ParseOne_Reader(Xmldoc);
			}
		}
		Xmldoc.Close();
		Xmldoc = null;
		if ( isEnd ) { CTimeProfiler.End(string.Format("{0}.Load", strFileName)); }
	}
	public static void LoadFromFile2(string strFileName, IXmlParse2 parseOne, bool isEnd = true)
	{
		CTimeProfiler.Begin(string.Format("{0}.Load", strFileName));

        XmlReader Xmldoc = GetXMLReader(strFileName);

		while ( Xmldoc.Read() )
		{
			if ( IsReadContinue(Xmldoc) )
			{
				parseOne.ParseOne_Reader2(Xmldoc);
			}
		}
		Xmldoc.Close();
		Xmldoc = null;
		if ( isEnd ) { CTimeProfiler.End(string.Format("{0}.Load", strFileName)); }
	}

    private static int m_loadCount;
    public static void StartLoadCount()
    {
        m_loadCount = 0;
    }
    public static bool IsOverLoadCount(int attributeCount)
    {
        m_loadCount += attributeCount;
        if (m_loadCount >= kLoadCountReader)
        {
            m_loadCount = 0;
            return true;
        }
        return false;
    }

    public static bool IsReadContinue_AttrNotCheck(XmlReader xmlRead)
    {
        if (xmlRead.IsStartElement()) // root 하위의 인자를 읽은 것인지 확인. (안하면 <?xml 부터 읽음)
        {
            if (!xmlRead.Name.Equals("root"))// root는 패스시킴. (안하려면 이 함수 처리를 밖에서 해야함)
            {
                return true;
            }
        }
        return false;
    }
    public static bool IsReadContinue(XmlReader xmlRead)
    {
        if (xmlRead.IsStartElement()) // root 하위의 인자를 읽은 것인지 확인. (안하면 <?xml 부터 읽음)
        {
            if (xmlRead.AttributeCount > 0) // 안의 값이 있는지 확인
            {
                if (xmlRead.Name.Equals("root")) { return false; } // root는 패스시킴. (안하려면 이 함수 처리를 밖에서 해야함)
                else
                {
                    return true;
                }
            }
        }
        return false;
    }

    #region Parse
    private static void TryParseError(XmlReader xmlRead, string key, string attribute)
    {
        Debugger.LogError(string.Format("[ERROR] TableName : {0} | name : {1}", xmlRead.Name, key));
    }
    private static void TryParseError(XmlReader xmlRead, string name)
    {
        TryParseError(xmlRead, name, xmlRead.GetAttribute(name));
    }
    private static void TryParseError(XmlReader xmlRead, int index)
    {
        TryParseError(xmlRead, index.ToString(), xmlRead.GetAttribute(index));
    }

    public static bool TryParse(XmlReader xmlRead, string name, out string value)
    {
        value = xmlRead.GetAttribute(name);
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, string name, out byte value)
    {
        if (!byte.TryParse(xmlRead.GetAttribute(name), out value))
        {
            TryParseError(xmlRead, name);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, string name, out bool value)
    {
        if (!bool.TryParse(xmlRead.GetAttribute(name), out value))
        {
            int tmp = 0;

            if (!int.TryParse(xmlRead.GetAttribute(name), out tmp))
            {
                TryParseError(xmlRead, name);
                value = false; return true;
            }
            else
            {
                value = (tmp != 0);
            }
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, string name, out int value)
    {
        if (!int.TryParse(xmlRead.GetAttribute(name), out value))
        {
            TryParseError(xmlRead, name);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, string name, out uint value)
    {
        if (!uint.TryParse(xmlRead.GetAttribute(name), out value))
        {
            TryParseError(xmlRead, name);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, string name, out short value)
    {
        if (!short.TryParse(xmlRead.GetAttribute(name), out value))
        {
            TryParseError(xmlRead, name);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, string name, out ushort value)
    {
        if (!ushort.TryParse(xmlRead.GetAttribute(name), out value))
        {
            TryParseError(xmlRead, name);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, string name, out float value)
    {
        if (!float.TryParse(xmlRead.GetAttribute(name), out value))
        {
            TryParseError(xmlRead, name);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, string name, out double value)
    {
        if (!double.TryParse(xmlRead.GetAttribute(name), out value))
        {
            TryParseError(xmlRead, name);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, string name, out long value)
    {
        if (!long.TryParse(xmlRead.GetAttribute(name), out value))
        {
            TryParseError(xmlRead, name);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, string name, out ulong value)
    {
        if (!ulong.TryParse(xmlRead.GetAttribute(name), out value))
        {
            TryParseError(xmlRead, name);
            value = 0; return true;
        }
        return false;
    }

    public static bool TryParse(XmlReader xmlRead, int index, out string value)
    {
        value = xmlRead.GetAttribute(index);
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, int index, out byte value)
    {
        if (!byte.TryParse(xmlRead.GetAttribute(index), out value))
        {
            TryParseError(xmlRead, index);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, int index, out bool value)
    {
        if (!bool.TryParse(xmlRead.GetAttribute(index), out value))
        {
            TryParseError(xmlRead, index);
            value = false; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, int index, out int value)
    {
        if (!int.TryParse(xmlRead.GetAttribute(index), out value))
        {
            TryParseError(xmlRead, index);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, int index, out uint value)
    {
        if (!uint.TryParse(xmlRead.GetAttribute(index), out value))
        {
            TryParseError(xmlRead, index);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, int index, out short value)
    {
        if (!short.TryParse(xmlRead.GetAttribute(index), out value))
        {
            TryParseError(xmlRead, index);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, int index, out ushort value)
    {
        if (!ushort.TryParse(xmlRead.GetAttribute(index), out value))
        {
            TryParseError(xmlRead, index);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, int index, out float value)
    {
        if (!float.TryParse(xmlRead.GetAttribute(index), out value))
        {
            TryParseError(xmlRead, index);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, int index, out double value)
    {
        if (!double.TryParse(xmlRead.GetAttribute(index), out value))
        {
            TryParseError(xmlRead, index);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, int index, out long value)
    {
        if (!long.TryParse(xmlRead.GetAttribute(index), out value))
        {
            TryParseError(xmlRead, index);
            value = 0; return true;
        }
        return false;
    }
    public static bool TryParse(XmlReader xmlRead, int index, out ulong value)
    {
        if (!ulong.TryParse(xmlRead.GetAttribute(index), out value))
        {
            TryParseError(xmlRead, index);
            value = 0; return true;
        }
        return false;
    }

    private static void Default_Warning(XmlReader xmlRead, string key, string attr, string defaultValue)
    {
        //Debugger.LogWarning(string.Format("Depth : {0} | LocalName : {1} | {2}", xmlRead.Depth, xmlRead.LocalName, xmlRead.QuoteChar));
        //Debugger.LogError(string.Format("[ERROR] URL : {3} | TableName : {0} | name : {1} | defaultValue : {2}", xmlRead.Name, key, defaultValue, xmlRead.BaseURI));
    }

    public static void TryParse_Default(XmlReader xmlRead, string name, out string value, string defaultValue)
    {
        if (xmlRead.GetAttribute(name) == "")
        {
            Default_Warning(xmlRead, name, xmlRead.GetAttribute(name), defaultValue);
            value = defaultValue;
        }
        else
        {
            TryParse(xmlRead, name, out value);
        }
    }
    public static void TryParse_Default(XmlReader xmlRead, string name, out float value, float defaultValue)
    {
        if (!float.TryParse(xmlRead.GetAttribute(name), out value))
        {
            Default_Warning(xmlRead, name, xmlRead.GetAttribute(name), defaultValue.ToString());
            value = defaultValue;
        }
        else
        {
            TryParse(xmlRead, name, out value);
        }
    }
    public static void TryParse_Default(XmlReader xmlRead, string name, out bool value, bool defaultValue)
    {
        if (!bool.TryParse(xmlRead.GetAttribute(name), out value))
        {
            Default_Warning(xmlRead, name, xmlRead.GetAttribute(name), defaultValue.ToString());
            value = defaultValue;
        }
        else
        {
            TryParse(xmlRead, name, out value);
        }
    }
    public static void TryParse_Default(XmlReader xmlRead, string name, out int value, int defaultValue)
    {
        if (!int.TryParse(xmlRead.GetAttribute(name), out value))
        {
            Default_Warning(xmlRead, name, xmlRead.GetAttribute(name), defaultValue.ToString());
            value = defaultValue;
        }
        else
        {
            TryParse(xmlRead, name, out value);
        }
    }

    public static void TryParse_Default(XmlReader xmlRead, int iElement, out string value, string defaultValue)
    {
        if (xmlRead.GetAttribute(iElement) == "")
        {
            Default_Warning(xmlRead, iElement.ToString(), xmlRead.GetAttribute(iElement), defaultValue);
            value = defaultValue;
        }
        else
        {
            TryParse(xmlRead, iElement, out value);
        }
    }
    public static void TryParse_Default(XmlReader xmlRead, int iElement, out int value, int defaultValue)
    {
        if (xmlRead.GetAttribute(iElement) == "")
        {
            Default_Warning(xmlRead, iElement.ToString(), xmlRead.GetAttribute(iElement), defaultValue.ToString());
            value = defaultValue;
        }
        else
        {
            TryParse(xmlRead, iElement, out value);
        }
    }
    #endregion
}

public interface IXmlParse
{
    bool ParseOne_Reader(XmlReader xmlRead);

    /*
    // 예외
    // playercard (CCardControl)
    // AI (CPlayerControl) ToDo
    // simulation (CSimulationControl) ToDo
    // SoundTable (CSoundControl2) ToDo
#if SERVER || TOOL
    public override void LoadFromFile()
    {
        XMLSwitcher.LoadFromeFile("FileName", this);
    }
#else
    public override IEnumerator LoadFromFile()
    {
        yield return XMLSwitcher.LoadFromFile_Patch("FileName", this);
    }
#endif

    public bool ParseOne_Reader(XmlReader xmlRead)
    { return false; }
    */
}

public interface IXmlParse2
{
    bool ParseOne_Reader2(XmlReader xmlRead);

    /*
#if SERVER || TOOL
    public override void LoadFromFile()
    {
        XMLSwitcher.LoadFromeFile2("FileName", this);
    }
#else
    public override IEnumerator LoadFromFile()
    {
        yield return XMLSwitcher.LoadFromFile_Patch2("FileName", this);
    }
#endif
	
    public bool ParseOne_Reader2(XmlReader xmlRead)
    { return false; }
    */
}

public interface IXmlParse3
{
    bool ParseOne_Reader3(XmlReader xmlRead);
    bool ParseOne_Reader4(XmlReader xmlRead);

    /*
#if SERVER || TOOL
    public override void LoadFromFile()
    {
        XMLSwitcher.LoadFromeFile3("FileName", this);
        XMLSwitcher.LoadFromeFile4("FileName", this);
    }
#else
    public override IEnumerator LoadFromFile()
    {
        yield return XMLSwitcher.LoadFromFile_Patch3("FileName", this);
        yield return XMLSwitcher.LoadFromFile_Patch4("FileName", this);
    }
#endif
	
    public bool ParseOne_Reader3(XmlReader xmlRead)
    { return false; }
    public bool ParseOne_Reader4(XmlReader xmlRead)
    { return false; }
    */
}