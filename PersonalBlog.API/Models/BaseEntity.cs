using System;
using System.ComponentModel.DataAnnotations;
using PersonalBlog.API.Common;

namespace PersonalBlog.API.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        [Timestamp]
        public byte[] RowVersion { set; get; }

    }
}