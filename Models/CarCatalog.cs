using System;
using System.Collections.Generic;

namespace CarAPI.Models;

public abstract class CarCatalog
{
    public int Id { get; set; }

    public string Dealer { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Price { get; set; } = null!;

    public int Milage { get; set; }

    public string Color { get; set; } = null!;

    virtual public string Active { get; set; }
}
public class CarCatalogDealer1 : CarCatalog
{
    public override string Active
    {
        get
        {
            if (base.Active == "Active")
            {
                return "ForSale";
            }
            else
            {

                return base.Active;

            }
        }
        set { }
    }

}

public class CarCatalogDealer2 : CarCatalog
{
    public override string Active
    {

        get
        {
            return base.Active;
        }
        set { }
    }

}
public class CarCatalogDealer3 : CarCatalog
{
    public override string Active
    {
        get { return base.Active; }
        set { }
    }

}