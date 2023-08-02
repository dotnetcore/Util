namespace Util.Helpers; 

/// <summary>
/// Xml操作 - 工具
/// </summary>
public partial class Xml {
    /// <summary>
    /// 将Xml字符串转换为XDocument
    /// </summary>
    /// <param name="xml">Xml字符串</param>
    public static XDocument ToDocument( string xml ) {
        return XDocument.Parse( xml );
    }

    /// <summary>
    /// 将Xml字符串转换为XElement列表
    /// </summary>
    /// <param name="xml">Xml字符串</param>
    public static List<XElement> ToElements( string xml ) {
        var document = ToDocument( xml );
        if( document?.Root == null )
            return new List<XElement>();
        return document.Root.Elements().ToList();
    }

    /// <summary>
    /// 加载Xml文件到XDocument
    /// </summary>
    /// <param name="filePath">Xml文件绝对路径</param>
    public static async Task<XDocument> LoadFileToDocumentAsync( string filePath ) {
        return await LoadFileToDocumentAsync( filePath, Encoding.UTF8 );
    }

    /// <summary>
    /// 加载Xml文件到XDocument
    /// </summary>
    /// <param name="filePath">Xml文件绝对路径</param>
    /// <param name="encoding">字符编码</param>
    public static async Task<XDocument> LoadFileToDocumentAsync( string filePath,Encoding encoding ) {
        var xml = await Util.Helpers.File.ReadToStringAsync( filePath, encoding );
        return ToDocument( xml );
    }

    /// <summary>
    /// 加载Xml文件到XElement列表
    /// </summary>
    /// <param name="filePath">Xml文件绝对路径</param>
    public static async Task<List<XElement>> LoadFileToElementsAsync( string filePath ) {
        return await LoadFileToElementsAsync( filePath, Encoding.UTF8 );
    }

    /// <summary>
    /// 加载Xml文件到XElement列表
    /// </summary>
    /// <param name="filePath">Xml文件绝对路径</param>
    /// <param name="encoding">字符编码</param>
    public static async Task<List<XElement>> LoadFileToElementsAsync( string filePath, Encoding encoding ) {
        var xml = await Util.Helpers.File.ReadToStringAsync( filePath, encoding );
        return ToElements( xml );
    }
}