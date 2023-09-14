using System.ComponentModel.DataAnnotations;

namespace o.Models;

public class ekin
{
    public int ekinId { get; set; }
    [Display(Name="Ekin Adı")]
    public string? ekinAdı { get; set; }
    [Display(Name="Ekin Fiyatı")]
    public string? ekinFiyat{get;set;}
    [Display(Name="Ekin Stock Durumu")]
    public string? ekinstock{get;set;}
    


    public int tarlaId {get;set;}
   //gezinti alanı
   public ICollection<ilac>? ilac {get;set;}

   public tarla? tarla {get;set;} 

}