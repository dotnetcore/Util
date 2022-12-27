namespace RazorEngineCore
{
    public abstract class RazorEngineTemplateBase<T> : RazorEngineTemplateBase
    {
        public new T Model { get; set; }
    }
}   