using System.Collections.Generic;
using InetworkingChallenge.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace InetworkingChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        public DemoController(){ }

        [HttpPost]
        [Route("convert")]
        public string Convert([FromBody] UnformattedData data){

        string output = "[";
        int columns_in_row = 0;
        bool open_column = true;

        for( int x=0; x<data.inputString.Length; x++ ){ 

            if(open_column == true){ //check if array open
                output += "[";
                open_column = false;
            }
            
            if( data.inputString[x]+"" == "," ){ //check for column end
                columns_in_row += 1;
                if(columns_in_row == data.columnCount){
                    columns_in_row = 0;
                    output += "]";
                    open_column = true;
                }
            }

            if( data.inputString[x]+"" == "," && open_column == false){
                output += data.inputString[x]+" ";
            }else  if( data.inputString[x]+"" != " "){
                output += data.inputString[x];
            }
        }
            output += "]]";
            return output;
        }

        [HttpPost]
        [Route("parse")]
        public List<Employee> Parse([FromBody] Employees data){
            return data.employees;
        }
    }
}
