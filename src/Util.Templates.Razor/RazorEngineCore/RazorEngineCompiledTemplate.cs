using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Util.Templates.Razor;
using Util.Templates.Razor.Helpers;

namespace RazorEngineCore
{
    public class RazorEngineCompiledTemplate : IRazorEngineCompiledTemplate
    {
        private readonly MemoryStream assemblyByteCode;
        private readonly Type templateType;

        internal RazorEngineCompiledTemplate(MemoryStream assemblyByteCode)
        {
            this.assemblyByteCode = assemblyByteCode;

            Assembly assembly = Assembly.Load(assemblyByteCode.ToArray());
            this.templateType = assembly.GetType("TemplateNamespace.Template");
        }

        public static IRazorEngineCompiledTemplate LoadFromFile(string fileName)
        {
            return LoadFromFileAsync(fileName: fileName).GetAwaiter().GetResult();
        }

        public static async Task<IRazorEngineCompiledTemplate> LoadFromFileAsync(string fileName)
        {
            MemoryStream memoryStream = new MemoryStream();
            
            using (FileStream fileStream = new FileStream(
                path: fileName, 
                mode: FileMode.Open, 
                access: FileAccess.Read,
                share: FileShare.None,
                bufferSize: 4096, 
                useAsync: true))
            {
                await fileStream.CopyToAsync(memoryStream);
            }
            
            return new RazorEngineCompiledTemplate(memoryStream);
        }
        
        public static IRazorEngineCompiledTemplate LoadFromStream(Stream stream)
        {
            return LoadFromStreamAsync(stream).GetAwaiter().GetResult();
        }
        
        public static async Task<IRazorEngineCompiledTemplate> LoadFromStreamAsync(Stream stream)
        {
            MemoryStream memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;
            
            return new RazorEngineCompiledTemplate(memoryStream);
        }

        public void SaveToStream(Stream stream)
        {
            this.SaveToStreamAsync(stream).GetAwaiter().GetResult();
        }

        public Task SaveToStreamAsync(Stream stream)
        {
            return this.assemblyByteCode.CopyToAsync(stream);
        }

        public void SaveToFile(string fileName)
        {
            this.SaveToFileAsync(fileName).GetAwaiter().GetResult();
        }
        
        public Task SaveToFileAsync(string fileName)
        {
            using (FileStream fileStream = new FileStream(
                path: fileName, 
                mode: FileMode.OpenOrCreate, 
                access: FileAccess.Write,
                share: FileShare.None,
                bufferSize: 4096, 
                useAsync: true))
            {
                return assemblyByteCode.CopyToAsync(fileStream);
            }
        }
        
        public string Run(object model = null)
        {
            return this.RunAsync(model).GetAwaiter().GetResult();
        }
        
        public async Task<string> RunAsync(object model = null)
        {
            if (model != null && model.IsAnonymous())
            {
                model = new AnonymousTypeWrapper(model);
            }

            IRazorEngineTemplate instance = (IRazorEngineTemplate) Activator.CreateInstance(this.templateType);
            instance.Model = model;
            instance.Html = new HtmlHelper( new RazorTemplateEngine( new RazorEngine() ) );

            await instance.ExecuteAsync();

            return instance.Result();
        }
    }
}