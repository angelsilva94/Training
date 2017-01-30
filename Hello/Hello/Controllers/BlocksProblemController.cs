using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hello.Models;
using BlocksProblem;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Hello.Controllers
{
    public class BlocksProblemController : ApiController
    {
        // GET: api/BlocksProblem
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BlocksProblem/5
        public HttpResponseMessage Get(int lenght)
        {

            return Request.CreateResponse(HttpStatusCode.OK,"bien");
        }

        // POST: api/BlocksProblem
        public string Post( [FromBody]BlockModel blockModel)
        {
            //blockModel.instructions = new List<Instructions>();


            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(BlockModel));



            Block block = new Block(blockModel.length);
            string res = null;
            int i = 0;// blockModel.instructions.Count;
            


            do {
                //Instructions ins = new Instructions();
                //ins.move = ""
                //String movement = 
                if (blockModel.instructions[i].move.ToUpper() == "MOVEONTO") {
                    block.MoveOnto(blockModel.instructions[i].A, blockModel.instructions[i].B);

                }
                else if (blockModel.instructions[i].move.ToUpper() == "MOVEOVER") {
                    block.MoveOver(blockModel.instructions[i].A, blockModel.instructions[i].B);
                }
                else if (blockModel.instructions[i].move.ToUpper() == "PILEONTO") {
                    block.PileOnto(blockModel.instructions[i].A, blockModel.instructions[i].B);
                }
                else if (blockModel.instructions[i].move.ToUpper() == "PILEOVER") {
                    block.PileOver(blockModel.instructions[i].A, blockModel.instructions[i].B);
                }
                i++;

            } while(i< blockModel.instructions.Count);
            for (int j = 0; j < blockModel.length; j++) {
                res += block.Print(j);
                //Console.WriteLine(obj.Print(i));
            }
            //blockModel.instructions[blockModel.instructions.Count - 1].move == "END"

            return res;

        }

        // PUT: api/BlocksProblem/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BlocksProblem/5
        public void Delete(int id)
        {
        }
    }
}
