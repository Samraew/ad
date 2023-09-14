using System.ComponentModel.DataAnnotations;

namespace o.Models;

public class tarla
{
    public int tarlaId { get; set; }
    [Display(Name="Tarla Adı")]
    public string? TarlaAdı { get; set; }
    [Display(Name="Tarla Genişlik")]
    public string? TarlaGenislik{get;set;}
    [Display(Name="Tarla Bölgesi")]
    public string? tarlaBolge{get;set;}


    public ICollection<ekin>? ekin{get;set;}


}