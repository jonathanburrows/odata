using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Models
{
  [Table("Shippers", Schema = "dbo")]
  public class Shipper
  {
    public string CompanyName
    {
      get;
      set;
    }
    public string Phone
    {
      get;
      set;
    }
    [Key]
    public int ShipperID
    {
      get;
      set;
    }


    [InverseProperty("Shipper")]
    public ICollection<Order> Orders { get; set; }
  }
}
