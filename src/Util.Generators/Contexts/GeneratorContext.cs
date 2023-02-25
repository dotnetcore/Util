using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Util.Generators.Configuration;
using Util.Generators.Properties;
using Util.Validation;

namespace Util.Generators.Contexts {
    /// <summary>
    /// 生成器上下文
    /// </summary>
    public class GeneratorContext {
        /// <summary>
        /// 初始化生成器上下文
        /// </summary>
        public GeneratorContext() {
            Projects = new List<ProjectContext>();
        }

        /// <summary>
        /// 模板根目录路径
        /// </summary>
        [Required( ErrorMessageResourceType = typeof( GeneratorResource ), ErrorMessageResourceName = "TemplateRootPathIsEmpty" )]
        public string TemplateRootPath { get; set; }
        /// <summary>
        /// 输出根目录路径
        /// </summary>
        [Required( ErrorMessageResourceType = typeof( GeneratorResource ), ErrorMessageResourceName = "OutputRootPathIsEmpty" )]
        public string OutputRootPath { get; set; }
        /// <summary>
        /// 消息上下文
        /// </summary>
        public MessageOptions Message { get; set; }
        /// <summary>
        /// 项目上下文列表
        /// </summary>
        public List<ProjectContext> Projects { get; }

        /// <summary>
        /// 验证
        /// </summary>
        public void Validate() {
            var validationResult = DataAnnotationValidation.Validate( this );
            if( validationResult.IsValid == false )
                throw new InvalidOperationException( validationResult.First().ErrorMessage );
            Projects.ForEach( t => t.Validate() );
        }

        /// <summary>
        /// 复制
        /// </summary>
        public GeneratorContext Clone() {
            var result = new GeneratorContext {
                TemplateRootPath = TemplateRootPath,
                OutputRootPath = OutputRootPath,
                Message = Message?.Clone()
            };
            Projects.ForEach( project => result.Projects.Add( project.Clone( result ) ) );
            return result;
        }
    }
}
