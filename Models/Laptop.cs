
namespace AspProj1.Models;
public class Laptop {

    public int id{get;set;}
    public string brandName{get;set;}
    public int ramGb{get;set;}
    public double price{get;set;}

    public string variantName{get;set;}
    public string processor{get;set;}
    public string cpuFrequency{get;set;}

    public int graphicRAM{get;set;}
    public string graphicBrand{get;set;}

    public Boolean ramUpGradePossible{get;set;}

    public string imageLink{get;set;}

    public Laptop(string brandName, int ramGb, double price, string variantName, string processor, string cpuFrequency, int graphicRAM, string graphicBrand, bool ramUpGradePossible,string imageLink,int id)
    {
        this.brandName = brandName;
        this.ramGb = ramGb;
        this.price = price;
        this.variantName = variantName;
        this.processor = processor;
        this.cpuFrequency = cpuFrequency;
        this.graphicRAM = graphicRAM;
        this.graphicBrand = graphicBrand;
        this.ramUpGradePossible = ramUpGradePossible;
        this.imageLink = imageLink;
        this.id= id;
    }


}