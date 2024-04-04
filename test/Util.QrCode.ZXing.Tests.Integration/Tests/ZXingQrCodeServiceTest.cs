using System.Drawing;
using System.Threading.Tasks;
using Util.Images;
using Xunit;
using Xunit.Abstractions;

namespace Util.QrCode.Tests;

/// <summary>
/// ZXing二维码服务
/// </summary>
public class ZXingQrCodeServiceTest {
    /// <summary>
    /// 二维码服务
    /// </summary>
    private readonly IQrCodeService _service;
    /// <summary>
    /// 测试输出
    /// </summary>
    private readonly ITestOutputHelper _output;
    /// <summary>
    /// 内容
    /// </summary>
    private readonly string _content;

    /// <summary>
    /// 测试初始化
    /// </summary>
    public ZXingQrCodeServiceTest( IQrCodeService service, ITestOutputHelper output ) {
        _service = service;
        _output = output;
        _content = "https://gitee.com/util-core/util";
    }

    /// <summary>
    /// 测试获取二维码流
    /// </summary>
    [Fact]
    public void TestToStream() {
        var result = _service.Content( _content ).ToStream();
        Util.Helpers.File.Write( "./test/ToStream.png", result );
    }

    /// <summary>
    /// 测试获取二维码字节流
    /// </summary>
    [Fact]
    public void TestToBytes() {
        var result = _service.Content( _content ).ToBytes();
        Util.Helpers.File.Write( "./test/ToBytes.png", result );
    }

    /// <summary>
    /// 测试获取二维码Base64字符串
    /// </summary>
    [Fact]
    public void TestToBase64_1() {
        var result = _service.Content( _content ).ToBase64();
        string base64 = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAKAAAACgCAYAAACLz2ctAAAACXBIWXMAAA7EAAAOxAGVKw4bAAADyklEQVR4nO3dQU4jOxRAUZB6/1vm/0lLPYiaCn7xdaXPGQMp4MqK43L519f/PiDy6wNCAiQlQFICJCVAUgIk9dcAPz8/P07x6NOileu7+vOqT6mu/m7Tf5dp3/39jICkBEhKgKQESOrpAHe8Ka/eRE//bisTiR2Trmk/uT4jICkBkhIgKQGSGgnwpDfHV9+8X131WPm6q9f3yI6J2An/NyMgKQGSEiApAZJ6uwB3TBpW3rxPT1bu7u0C5F4ESEqApARI6tYBrrxRn16RmF5FOWl/yivdOkDuT4CkBEhKgKRGAjxp83Z1u9P0CswOJ0xqjICkBEhKgKQESOrpAE96E33Vjv0fJ33dI6f+34yApARISoCkBEjqrwF+HX77z+mP2b36und8EtYUIyApAZISICkBkho5J2THp/Erb+ivXsvKZGDH5Gfl51W3izknhKMJkJQASQmQ1MtWQnZMYHY89errDTeD/7bjNrDvGAFJCZCUAEkJkNTL9oTsWFXYsUdix8rASXtMph8/bCWEowmQlABJCZDUywLcMeGYvpYdhxWedBvY9MTuJ6sjRkBSAiQlQFICJPV0gNO3J01/Gn9VtRl85fednqxc9coDFo2ApARISoCkBEgqXwl5pPqEfvogwZP2mOzY1P4TRkBSAiQlQFICJJWfE3LSrVcrX7di5ZqrAxGnJiZGQFICJCVAUgIk9bIAp59cNX0tj0yvcOw4J6RabZma6BgBSQmQlABJCZDUyJ6QHSsXK3bsuZh+3WnVOSHfMQKSEiApAZISIKmnDyuc/sT/qunH8e7Yw3H6GSMn7G0xApISICkBkhIgqa2HFZ5+MOHVa1l5jR2rDztWb6ZWeYyApARISoCkBEhqJMAdk4YddjyV61+7ves7RkBSAiQlQFICJPX07VhX7VilqL73dDvOO3E7Fm9BgKQESEqApF52O9aKldu2pl93xzkh1d6M6YMTf8IISEqApARISoCkXrYSMm1lQ/z06z6yY4Kw8r2n3qJlBCQlQFICJCVAUiOP6J1WnZGxY0Vix2b16Sd6rawGfccISEqApARISoCkXrYx/arpSc2OW6Cmr+WRlcnAih0TrD8ZAUkJkJQASQmQ1K0DrPZw7FCtmOzeJ3LrALk/AZISICkBknq7AKc3tZ+0yjP9utMTHSsh3I4ASQmQlABJjQR40mrBCqsjno7FP0aApARISoCkng7wpCdmrTjp5PLqKV+79388YgQkJUBSAiQlQFJHnhNy1fT1nfTzdnxvdX1/MgKSEiApAZISICkBkhIgKQGS+g/OvjqVV+EClwAAAABJRU5ErkJggg==";
        _output.WriteLine( result );
        Assert.Equal( base64, result );
    }

    /// <summary>
    /// 测试获取二维码Base64字符串 - 设置图片类型
    /// </summary>
    [Fact]
    public void TestToBase64_2() {
        var result = _service.Content( _content ).ImageType( ImageType.Jpg ).ToBase64();
        string base64 = "data:image/jpeg;base64,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";
        _output.WriteLine( result );
        Assert.Equal( base64, result );
    }

    /// <summary>
    /// 测试保存二维码图片
    /// </summary>
    [Fact]
    public void TestSave() {
        _service.Content( _content ).Save( "./test/Save.png" );
    }

    /// <summary>
    /// 测试获取二维码流
    /// </summary>
    [Fact]
    public async Task TestToStreamAsync() {
        var result = await _service.Content( _content ).ToStreamAsync();
        await Util.Helpers.File.WriteAsync( "./test/ToStreamAsync.png", result );
    }

    /// <summary>
    /// 测试获取二维码字节流
    /// </summary>
    [Fact]
    public async Task TestToBytesAsync() {
        var result = await _service.Content( _content ).ToBytesAsync();
        await Util.Helpers.File.WriteAsync( "./test/ToBytesAsync.png", result );
    }

    /// <summary>
    /// 测试保存二维码图片
    /// </summary>
    [Fact]
    public async Task TestSaveAsync_1() {
        await _service.Content( _content ).SaveAsync( "./test/SaveAsync_1.png" );
    }

    /// <summary>
    /// 测试保存二维码图片 - 设置二维码尺寸
    /// </summary>
    [Fact]
    public async Task TestSaveAsync_2() {
        await _service.Content( _content ).Size( QrSize.Small ).SaveAsync( "./test/SaveAsync_Small.png" );
        await _service.Content( _content ).Size( QrSize.Middle ).SaveAsync( "./test/SaveAsync_Middle.png" );
        await _service.Content( _content ).Size( QrSize.Large ).SaveAsync( "./test/SaveAsync_Large.png" );
    }

    /// <summary>
    /// 测试保存二维码图片 - 设置前景色
    /// </summary>
    [Fact]
    public async Task TestSaveAsync_3() {
        await _service.Content( _content ).Color( Color.Red ).SaveAsync( "./test/SaveAsync_3.png" );
    }

    /// <summary>
    /// 测试保存二维码图片 - 设置背景色
    /// </summary>
    [Fact]
    public async Task TestSaveAsync_4() {
        await _service.Content( _content ).BgColor( Color.Aquamarine ).SaveAsync( "./test/SaveAsync_4.png" );
    }

    /// <summary>
    /// 测试保存二维码图片 - 设置边距
    /// </summary>
    [Fact]
    public async Task TestSaveAsync_5() {
        await _service.Content( _content ).Margin( 5 ).SaveAsync( "./test/SaveAsync_5.png" );
    }

    /// <summary>
    /// 测试保存二维码图片 - 设置图标
    /// </summary>
    [Fact]
    public async Task TestSaveAsync_6() {
        var iconPath = Util.Helpers.Common.GetPhysicalPath( "./Icons/icon.jpg" );
        await _service.Content( _content ).Icon( iconPath ).SaveAsync( "./test/SaveAsync_6.png" );
    }
}