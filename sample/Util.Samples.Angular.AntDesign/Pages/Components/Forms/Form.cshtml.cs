﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Util.Applications.Dtos;
using Util.Biz.Enums;
using Util.Samples.Models.Tools;

namespace Util.Samples.Pages.Components.Forms {
    /// <summary>
    /// 基础表单
    /// </summary>
    public class FormModel : RequestBase {
        /// <summary>
        /// 编码
        /// </summary>
        [Display( Name = "编码" )]
        public string Code { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required( ErrorMessage = "姓名不能为空" )]
        [StringLength( 10 )]
        [Display( Name = "姓名" )]
        public string Name { get; set; }

        /// <summary>
        /// 颜色
        /// </summary>
        [Display( Name = "颜色" )]
        public string Color { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Display( Name = "年龄" )]
        public double? Age { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        [Display( Name = "是否禁用" )]
        public bool? Enabled { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display( Name = "性别" )]
        public Gender? Gender { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        [Display( Name = "民族" )]
        public Nation? Nation { get; set; }

        /// <summary>
        /// 日期时间
        /// </summary>
        [Display( Name = "日期时间" )]
        public DateTime? DateTime { get; set; }

        /// <summary>
        /// 上传文件列表
        /// </summary>
        [Display( Name = "上传文件列表" )]
        public List<UploadFileInfo> Files { get; set; }

        /// <summary>
        /// 上传文件
        /// </summary>
        [Display( Name = "上传文件" )]
        public UploadFileInfo File { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display( Name = "备注" )]
        public string Comment { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [Display( Name = "备注" )]
        public string Comment2 { get; set; }
    }
}
