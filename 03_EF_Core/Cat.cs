using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

[Table("T_Cats")]
public class Cat
{
    [Key] // 主键
    public int Id { get; set; }

    [Required] // 非空
    [MaxLength(22)] // 长度
    public string Name { get; set; }

    [Column("NameTwo")] // 字段名
    public string Name2 { get; set; }


    [Column("CreatedAt", TypeName ="timestamp")] // 字段名 及 类型
    public DateTime Created { get; set; }

    [DefaultValue("Now()")]
    public DateTime Updated { get; set; }

    [NotMapped] // Ignore the Version property
    public int Version { get; set; }
}