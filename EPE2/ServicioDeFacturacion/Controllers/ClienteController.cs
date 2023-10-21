using Microsoft.AspNetCore.Mvc;

namespace EPE2.Controller;

public class Empresa:ControllerBase{
    public Empresas[] Datos_Empresa = new Empresas []{

        new Empresas {Id= 1, Rut_Cliente = 23416718, Nombre_Cliente = "Ana", Apellido_Cliente = "Urbano", edad_Cliente = 49,  Nombre_Empresa = "fritoLey", Rut_Empresa = 11174528, Giro_Empresa = "Frituras",Total_ventas = 300, Monto_ventas_hechas = 3000000, IVA_Pagar= 570000, Utilidades= 2430000},
        new Empresas {Id= 2, Rut_Cliente = 28745982, Nombre_Cliente = "Alberto", Apellido_Cliente = "Petro", edad_Cliente = 52, Nombre_Empresa = "yupy", Rut_Empresa = 14478412, Giro_Empresa = "Frituras",Total_ventas = 300, Monto_ventas_hechas = 3000000, IVA_Pagar=570000, Utilidades= 2430000 },
        new Empresas {Id= 3, Rut_Cliente = 12547892, Nombre_Cliente = "Gabi", Apellido_Cliente = "Murillo", edad_Cliente = 39, Nombre_Empresa = "super", Rut_Empresa = 19998547, Giro_Empresa = "Frituras",Total_ventas = 300, Monto_ventas_hechas = 3000000, IVA_Pagar= 570000, Utilidades= 2430000},


    };
// en este metodo listamos el total de datos de la empresa

    [HttpGet]
    [Route("Total de Empresas")]

    public IActionResult Listar(){

     try{

        if (Datos_Empresa != null){

         for(int a=0; a < Datos_Empresa.Length; a++){

         Console.WriteLine(Datos_Empresa[a]);

        }
//imprimimos el status code 200 que es correcto

    return StatusCode(200, Datos_Empresa);

         }else{

   //imprimimos en consola que no se encontar los datos

          return StatusCode(404, "No se encontraron los datos");

             }

         }catch(Exception){

            return StatusCode(401, "No se encontraron los datos");


            }

        }


// listamos datos de una empresa en especifico

    [HttpGet]
    [Route("Empresa por ID")]

    public IActionResult ListareEmpresaID(int id){


        //creamos elemento de control para recorrer el arreglo

        if (id > 0 && id <= Datos_Empresa.Length){

            //imprimimos en consola que se encontro la Empresa

            Console.WriteLine("Se encontro la empresa");

            //imprimimos el status code 200 que es correcto

            return StatusCode(200, Datos_Empresa[id-1]);


        }else{

            //imprimimos en consola que no se encontro la Empresa

            Console.WriteLine("empresa No encontrada");
            return StatusCode(404);

        }

    }

    [HttpPost]
    [Route("Crear Nueva Empresa")]
    public IActionResult CrearEmpresa([FromBody] Empresas empresas){


        //generamos un elemento de control para el ingreso de nueva Empresa
        if(Datos_Empresa != null){

            //imprimimos en consola que se creo correctamente la empresa

            Console.WriteLine("Se creo la empresa");
            return StatusCode(201, Datos_Empresa);
            
            }else{

                //imprimimos en consola que no se creo correctamente la Empresa

                Console.WriteLine("No se pudo crear la empresa");
                return StatusCode(404);
                
                }

    }




// en el metodo post editaremos y guardaremos los cambios requeridos de una empresa 

   [HttpPut]
    [Route("Editar informacion de Empresa")]

    public IActionResult EditarEmpresas(int id, [FromBody] Empresas empresas){


        //creamos elemento de control para recorrer el arreglo

        if (id > 0 && id <= Datos_Empresa.Length){

            //procedemos a realizar cambios  de la empresa

                Datos_Empresa[id-1].Nombre_Cliente=empresas.Nombre_Cliente;
                Datos_Empresa[id-1].Apellido_Cliente=empresas.Apellido_Cliente;
                Datos_Empresa[id-1].edad_Cliente=empresas.edad_Cliente;
                Datos_Empresa[id-1].Rut_Cliente=empresas.Rut_Cliente;
                Datos_Empresa[id-1].Nombre_Empresa=empresas.Nombre_Empresa;
                Datos_Empresa[id-1].Rut_Empresa = empresas.Rut_Empresa;
                Datos_Empresa[id-1].Giro_Empresa = empresas.Giro_Empresa;
                Datos_Empresa[id-1].Total_ventas = empresas.Total_ventas;
                Datos_Empresa[id-1].Monto_ventas_hechas = empresas.Monto_ventas_hechas;
                Datos_Empresa[id-1].IVA_Pagar = empresas.IVA_Pagar;
                Datos_Empresa[id-1].Utilidades = empresas.Utilidades;
            
            //imprimimos el status code 200 que es correcto

            return StatusCode(200, Datos_Empresa[id-1]);

        }else if(id==0){

            //imprimimos en consola que no se encontar los datos

            Console.WriteLine("Persona No encontrada");
            return StatusCode(404);


        }else{

            //imprimimos que no se pudo editar los datos
            
            Console.WriteLine("No se pudo editar la Empresa");
            return StatusCode(400);

        }


        
    }

    [HttpDelete]
    [Route("Empresa_Eliminar por/{id}")]

    public IActionResult BorrarEmpresa(int id){

        //creamos elemento de control para recorrer el arreglo
        if (id > 0 && id <= Datos_Empresa.Length){

            //procedemos a la eliminacion de la Empresa
            Datos_Empresa[id-1] = null;
            
            //imprimimos el status code 200 que es correcto
            return StatusCode(200, Datos_Empresa);
            
         
            }else{

                //imprimimos en consola que no se encontraron los datos 
                Console.WriteLine("Datos No encontrados");
                return StatusCode(404);
                
                }

    }
}






