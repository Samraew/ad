using System.ComponentModel.DataAnnotations;

namespace o.Models;

public class ilac
{
    public int ilacId { get; set; }
    [Display(Name="İlac Adı")]
    public string? ilacAdı { get; set; }
    [Display(Name="İlaç Fiyatı")]
    public string? ilacFiyat{get;set;}
    [Display(Name="İlaç Stock Durumuı")]
    public string? ilacStock{get;set;}
    public string? ilacadın {get; set;}
    
    public int ekinId {get;set;}

   public ekin? ekin{get;set;}

}