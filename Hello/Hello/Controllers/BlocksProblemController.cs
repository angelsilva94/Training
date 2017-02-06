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
using Models;
using Libraries;

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
        public HttpResponseMessage Post(BlockModel blockModel)
        {
            if(blockModel != null) {
                ValidatorBlocks validatorBlocks = new ValidatorBlocks { number = blockModel.length };
                ErrorDispose errorDispose;
                if (validatorBlocks.Val(out errorDispose)){
                    Block block = new Block(blockModel.length);
                    int longt = blockModel.length;
                    int i = 0;

                    do {
                        if (blockModel.instructions[i].move.ToUpper() == "MOVEONTO") {
                            block.MoveOnto(blockModel.instructions[i].A, blockModel.instructions[i].B);

                        } else if (blockModel.instructions[i].move.ToUpper() == "MOVEOVER") {
                            block.MoveOver(blockModel.instructions[i].A, blockModel.instructions[i].B);
                        } else if (blockModel.instructions[i].move.ToUpper() == "PILEONTO") {
                            block.PileOnto(blockModel.instructions[i].A, blockModel.instructions[i].B);
                        } else if (blockModel.instructions[i].move.ToUpper() == "PILEOVER") {
                            block.PileOver(blockModel.instructions[i].A, blockModel.instructions[i].B);
                        }
                        i++;
                    } while (i < blockModel.instructions.Count);
                    for (int j = 0; j < blockModel.length; j++) {
                        blockModel.res += block.Print(j);
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, blockModel);

                } else {
                    return Request.CreateResponse(HttpStatusCode.NotFound, errorDispose);
                }

            } else {
                return Request.CreateResponse(HttpStatusCode.NotFound, new ErrorDispose { ErrorCode=10,ErrorDesc="tienes mal tus parametros"});
            }
                
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
