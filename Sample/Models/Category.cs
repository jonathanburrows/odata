using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Sample.Models
{
  [Table("Categories", Schema = "dbo")]
  public class Category
  {
    [Key]
    public int CategoryID
    {
      get;
      set;
    }


    [InverseProperty("Category")]
    public ICollection<Product> Products { get; set; }
    public string CategoryName
    {
      get;
      set;
    }
    public string Description
    {
      get;
      set;
    }
    public Byte[] Picture
    {
      get;
      set;
    }
  }
}
