using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetearIngredientes : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

   
    [Header("Ingredientes")]
    public List<Carne> ingredietesCarne = new List<Carne>();
    public List<Verdura> ingredietesVerdura = new List<Verdura>();
    public List<Salsa> ingredietesSalsa = new List<Salsa>();

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    
    public void resetearIngredientes()
    {
            resetearTernera();
            resetearPollo();
            resetearFalafel();
            resetearCordero();
            resetearCamello();
            resetearYogurt();
            resetearPicante();
            resetearCurry();
            resetearDeluxe();
            resetearTomate();
            resetearLechuga();
            resetearCebollaBlanca();
            resetearMaiz();
            resetearPepino();
            resetearCol();
            resetearPimiento();
            resetearBrocoli();
    }


    //--------------------------------------------------------------------------------//
    //---------------------------------------- Carnes --------------------------------//

    public void resetearTernera()
    {
        ingredietesCarne[0].nombre = "Ternera";
        ingredietesCarne[0].nivel = 0;
        ingredietesCarne[0].unidadesCocina = 5;
        ingredietesCarne[0].unidadesAlmacen = 0;
        ingredietesCarne[0].capacidadMaxIngrediente = 5;
        ingredietesCarne[0].estaDesbloqueado = true;
        ingredietesCarne[0].estaComprado = true;
        ingredietesCarne[0].DesbloqueoCompra = 0;
        ingredietesCarne[0].DesbloqueoMejora = 2;
        ingredietesCarne[0].costeCompra = 0;
        ingredietesCarne[0].costeCompraUnidades = 5;
        ingredietesCarne[0].costeMejora = 30;
        ingredietesCarne[0].precioVenta = 10;
    }

    public void resetearPollo()
    {
        ingredietesCarne[1].nombre = "Pollo en jaula";
        ingredietesCarne[1].nivel = 0;
        ingredietesCarne[1].unidadesCocina = 5;
        ingredietesCarne[1].unidadesAlmacen = 0;
        ingredietesCarne[1].capacidadMaxIngrediente = 5;
        ingredietesCarne[1].estaDesbloqueado = true;
        ingredietesCarne[1].estaComprado = true;
        ingredietesCarne[1].DesbloqueoCompra = 0;
        ingredietesCarne[1].DesbloqueoMejora = 3;
        ingredietesCarne[1].costeCompra = 0;
        ingredietesCarne[1].costeCompraUnidades = 5;
        ingredietesCarne[1].costeMejora = 50;
        ingredietesCarne[1].precioVenta = 10;
    }

    public void resetearFalafel()
    {
        ingredietesCarne[2].nombre = "Falafel";
        ingredietesCarne[2].nivel = 0;
        ingredietesCarne[2].unidadesCocina = 5;
        ingredietesCarne[2].unidadesAlmacen = 0;
        ingredietesCarne[2].capacidadMaxIngrediente = 5;
        ingredietesCarne[2].estaDesbloqueado = false;
        ingredietesCarne[2].estaComprado = false;
        ingredietesCarne[2].DesbloqueoCompra = 2;
        ingredietesCarne[2].DesbloqueoMejora = 4;
        ingredietesCarne[2].costeCompra = 30;
        ingredietesCarne[2].costeCompraUnidades = 5;
        ingredietesCarne[2].costeMejora = 75;
        ingredietesCarne[2].precioVenta = 15;
    }

    public void resetearCordero()
    {
        ingredietesCarne[3].nombre = "Cordero";
        ingredietesCarne[3].nivel = 0;
        ingredietesCarne[3].unidadesCocina = 0;
        ingredietesCarne[3].unidadesAlmacen = 0;
        ingredietesCarne[3].capacidadMaxIngrediente = 5;
        ingredietesCarne[3].estaDesbloqueado = false;
        ingredietesCarne[3].estaComprado = false;
        ingredietesCarne[3].DesbloqueoCompra = 5;
        ingredietesCarne[3].DesbloqueoMejora = 7;
        ingredietesCarne[3].costeCompra = 100;
        ingredietesCarne[3].costeCompraUnidades = 5;
        ingredietesCarne[3].costeMejora = 210;
        ingredietesCarne[3].precioVenta = 30;
    }

    public void resetearCamello()
    {
        ingredietesCarne[4].nombre = "Camello";
        ingredietesCarne[4].nivel = 0;
        ingredietesCarne[4].unidadesCocina = 0;
        ingredietesCarne[4].unidadesAlmacen = 0;
        ingredietesCarne[4].capacidadMaxIngrediente = 5;
        ingredietesCarne[4].estaDesbloqueado = false;
        ingredietesCarne[4].estaComprado = false;
        ingredietesCarne[4].DesbloqueoCompra = 8;
        ingredietesCarne[4].DesbloqueoMejora = 9;
        ingredietesCarne[4].costeCompra = 250;
        ingredietesCarne[4].costeCompraUnidades = 5;
        ingredietesCarne[4].costeMejora = 275;
        ingredietesCarne[4].precioVenta = 45;
    }

    //--------------------------------------------------------------------------------//
    //--------------------------------------- Salsas ---------------------------------//

    public void resetearYogurt()
    {
        ingredietesSalsa[0].nombre = "Yogurt";
        ingredietesSalsa[0].nivel = 0;
        ingredietesSalsa[0].unidadesCocina = 5;
        ingredietesSalsa[0].unidadesAlmacen = 0;
        ingredietesSalsa[0].capacidadMaxIngrediente = 5;
        ingredietesSalsa[0].estaDesbloqueado = true;
        ingredietesSalsa[0].estaComprado = true;
        ingredietesSalsa[0].DesbloqueoCompra = 0;
        ingredietesSalsa[0].DesbloqueoMejora = 3;
        ingredietesSalsa[0].costeCompra = 0;
        ingredietesSalsa[0].costeCompraUnidades = 5;
        ingredietesSalsa[0].costeMejora = 50;
        ingredietesSalsa[0].precioVenta = 10;
    }

    public void resetearPicante()
    {
        ingredietesSalsa[1].nombre = "Picante";
        ingredietesSalsa[1].nivel = 0;
        ingredietesSalsa[1].unidadesCocina = 0;
        ingredietesSalsa[1].unidadesAlmacen = 0;
        ingredietesSalsa[1].capacidadMaxIngrediente = 5;
        ingredietesSalsa[1].estaDesbloqueado = false;
        ingredietesSalsa[1].estaComprado = false;
        ingredietesSalsa[1].DesbloqueoCompra = 2;
        ingredietesSalsa[1].DesbloqueoMejora = 5;
        ingredietesSalsa[1].costeCompra = 30;
        ingredietesSalsa[1].costeCompraUnidades = 5;
        ingredietesSalsa[1].costeMejora = 100;
        ingredietesSalsa[1].precioVenta = 15;
    }

    public void resetearCurry()
    {
        ingredietesSalsa[2].nombre = "Curry";
        ingredietesSalsa[2].nivel = 0;
        ingredietesSalsa[2].unidadesCocina = 0;
        ingredietesSalsa[2].unidadesAlmacen = 0;
        ingredietesSalsa[2].capacidadMaxIngrediente = 5;
        ingredietesSalsa[2].estaDesbloqueado = false;
        ingredietesSalsa[2].estaComprado = false;
        ingredietesSalsa[2].DesbloqueoCompra = 4;
        ingredietesSalsa[2].DesbloqueoMejora = 6;
        ingredietesSalsa[2].costeCompra = 75;
        ingredietesSalsa[2].costeCompraUnidades = 5;
        ingredietesSalsa[2].costeMejora = 140;
        ingredietesSalsa[2].precioVenta = 25;
    }

    public void resetearDeluxe()
    {
        ingredietesSalsa[3].nombre = "Deluxe";
        ingredietesSalsa[3].nivel = 0;
        ingredietesSalsa[3].unidadesCocina = 0;
        ingredietesSalsa[3].unidadesAlmacen = 0;
        ingredietesSalsa[3].capacidadMaxIngrediente = 5;
        ingredietesSalsa[3].estaDesbloqueado = false;
        ingredietesSalsa[3].estaComprado = false;
        ingredietesSalsa[3].DesbloqueoCompra = 8;
        ingredietesSalsa[3].DesbloqueoMejora = 9;
        ingredietesSalsa[3].costeCompra = 250;
        ingredietesSalsa[3].costeCompraUnidades = 5;
        ingredietesSalsa[3].costeMejora = 300;
        ingredietesSalsa[3].precioVenta = 45;
    }

    //--------------------------------------------------------------------------------//
    //------------------------------------- Verduras ---------------------------------//

    public void resetearTomate()
    {
        ingredietesVerdura[0].nombre = "Tomate";
        ingredietesVerdura[0].nivel = 0;
        ingredietesVerdura[0].unidadesCocina = 5;
        ingredietesVerdura[0].unidadesAlmacen = 0;
        ingredietesVerdura[0].capacidadMaxIngrediente = 5;
        ingredietesVerdura[0].estaDesbloqueado = true;
        ingredietesVerdura[0].estaComprado = true;
        ingredietesVerdura[0].DesbloqueoCompra = 0;
        ingredietesVerdura[0].DesbloqueoMejora = 3;
        ingredietesVerdura[0].costeCompra = 0;
        ingredietesVerdura[0].costeCompraUnidades = 5;
        ingredietesVerdura[0].costeMejora = 50;
        ingredietesVerdura[0].precioVenta = 10;
    }

    public void resetearLechuga()
    {
        ingredietesVerdura[1].nombre = "Lechuga";
        ingredietesVerdura[1].nivel = 0;
        ingredietesVerdura[1].unidadesCocina = 5;
        ingredietesVerdura[1].unidadesAlmacen = 0;
        ingredietesVerdura[1].capacidadMaxIngrediente = 5;
        ingredietesVerdura[1].estaDesbloqueado = true;
        ingredietesVerdura[1].estaComprado = true;
        ingredietesVerdura[1].DesbloqueoCompra = 0;
        ingredietesVerdura[1].DesbloqueoMejora = 4;
        ingredietesVerdura[1].costeCompra = 0;
        ingredietesVerdura[1].costeCompraUnidades = 5;
        ingredietesVerdura[1].costeMejora = 75;
        ingredietesVerdura[1].precioVenta = 10;
    }

    public void resetearCebollaBlanca()
    {
        ingredietesVerdura[2].nombre = "Cebolla Blanca";
        ingredietesVerdura[2].nivel = 0;
        ingredietesVerdura[2].unidadesCocina = 5;
        ingredietesVerdura[2].unidadesAlmacen = 0;
        ingredietesVerdura[2].capacidadMaxIngrediente = 5;
        ingredietesVerdura[2].estaDesbloqueado = true;
        ingredietesVerdura[2].estaComprado = true;
        ingredietesVerdura[2].DesbloqueoCompra = 0;
        ingredietesVerdura[2].DesbloqueoMejora = 2;
        ingredietesVerdura[2].costeCompra = 0;
        ingredietesVerdura[2].costeCompraUnidades = 5;
        ingredietesVerdura[2].costeMejora = 30;
        ingredietesVerdura[2].precioVenta = 10;
    } 
    
    public void resetearMaiz()
    {
        ingredietesVerdura[3].nombre = "Maiz";
        ingredietesVerdura[3].nivel = 0;
        ingredietesVerdura[3].unidadesCocina = 0;
        ingredietesVerdura[3].unidadesAlmacen = 0;
        ingredietesVerdura[3].capacidadMaxIngrediente = 5;
        ingredietesVerdura[3].estaDesbloqueado = false;
        ingredietesVerdura[3].estaComprado = false;
        ingredietesVerdura[3].DesbloqueoCompra = 3;
        ingredietesVerdura[3].DesbloqueoMejora = 4;
        ingredietesVerdura[3].costeCompra = 50;
        ingredietesVerdura[3].costeCompraUnidades = 5;
        ingredietesVerdura[3].costeMejora = 75;
        ingredietesVerdura[3].precioVenta = 20;
    }

    public void resetearPepino()
    {
        ingredietesVerdura[4].nombre = "Pepino";
        ingredietesVerdura[4].nivel = 0;
        ingredietesVerdura[4].unidadesCocina = 0;
        ingredietesVerdura[4].unidadesAlmacen = 0;
        ingredietesVerdura[4].capacidadMaxIngrediente = 5;
        ingredietesVerdura[4].estaDesbloqueado = false;
        ingredietesVerdura[4].estaComprado = false;
        ingredietesVerdura[4].DesbloqueoCompra = 4;
        ingredietesVerdura[4].DesbloqueoMejora = 6;
        ingredietesVerdura[4].costeCompra = 75;
        ingredietesVerdura[4].costeCompraUnidades = 5;
        ingredietesVerdura[4].costeMejora = 140;
        ingredietesVerdura[4].precioVenta = 25;
    }

    public void resetearCol()
    {
        ingredietesVerdura[5].nombre = "Col";
        ingredietesVerdura[5].nivel = 0;
        ingredietesVerdura[5].unidadesCocina = 0;
        ingredietesVerdura[5].unidadesAlmacen = 0;
        ingredietesVerdura[5].capacidadMaxIngrediente = 5;
        ingredietesVerdura[5].estaDesbloqueado = false;
        ingredietesVerdura[5].estaComprado = false;
        ingredietesVerdura[5].DesbloqueoCompra = 5;
        ingredietesVerdura[5].DesbloqueoMejora = 7;
        ingredietesVerdura[5].costeCompra = 100;
        ingredietesVerdura[5].costeCompraUnidades = 5;
        ingredietesVerdura[5].costeMejora = 210;
        ingredietesVerdura[5].precioVenta = 30;
    }

    public void resetearPimiento()
    {
        ingredietesVerdura[6].nombre = "Pimiento";
        ingredietesVerdura[6].nivel = 0;
        ingredietesVerdura[6].unidadesCocina = 0;
        ingredietesVerdura[6].unidadesAlmacen = 0;
        ingredietesVerdura[6].capacidadMaxIngrediente = 5;
        ingredietesVerdura[6].estaDesbloqueado = false;
        ingredietesVerdura[6].estaComprado = false;
        ingredietesVerdura[6].DesbloqueoCompra = 6;
        ingredietesVerdura[6].DesbloqueoMejora = 7;
        ingredietesVerdura[6].costeCompra = 140;
        ingredietesVerdura[6].costeCompraUnidades = 5;
        ingredietesVerdura[6].costeMejora = 210;
        ingredietesVerdura[6].precioVenta = 35;
    }

    public void resetearBrocoli()
    {
        ingredietesVerdura[7].nombre = "Brocoli";
        ingredietesVerdura[7].nivel = 0;
        ingredietesVerdura[7].unidadesCocina = 0;
        ingredietesVerdura[7].unidadesAlmacen = 0;
        ingredietesVerdura[7].capacidadMaxIngrediente = 5;
        ingredietesVerdura[7].estaDesbloqueado = false;
        ingredietesVerdura[7].estaComprado = false;
        ingredietesVerdura[7].DesbloqueoCompra = 8;
        ingredietesVerdura[7].DesbloqueoMejora = 9;
        ingredietesVerdura[7].costeCompra = 250;
        ingredietesVerdura[7].costeCompraUnidades = 5;
        ingredietesVerdura[7].costeMejora = 300;
        ingredietesVerdura[7].precioVenta = 45;
    }
}

