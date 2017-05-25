using System.Linq;
using apiEntity.Models;
using Microsoft.AspNetCore.Mvc;
namespace apiEntity.Controllers {
    [RouteAttribute ("api/[controller]")]
    public class toDoController : Controller {

        private readonly todoContext context;
        //Constructor
        public toDoController (todoContext context) {
                this.context = context;
                if (this.context.TodoItems.Count () == 0) {
                    this.context.TodoItems.Add (new todoModel { name = "item1" });
                    this.context.SaveChanges ();
                }
            }
        [HttpGetAttribute]
        public IActionResult GetItems () {
                return Ok (context.TodoItems.ToList ());
            }
        [HttpGetAttribute ("{id}",Name = "getItem")]
        public IActionResult getById (int id) {
            if (context.TodoItems.FirstOrDefault (x => x.id == id) == null) {
                return NotFound ();
            }
            return Ok (context.TodoItems.FirstOrDefault (x => x.id == id));
        }
        [HttpPostAttribute]
        public IActionResult postItem([FromBodyAttribute]todoModel item){
            if(item==null){
                return BadRequest();
            }
            context.Add(item);
            context.SaveChanges();
            return CreatedAtRoute("getItem",new {id=item.id},item);
        }
        [HttpPutAttribute]
        public IActionResult putItem(int id,[FromBodyAttribute] todoModel item){
            if(id==null||item.id==id){
                return BadRequest();
            }
            var todo = context.TodoItems.FirstOrDefault(x => x.id == id);
            if(todo==null){
                return NotFound();
            }
            todo.isComplete = item.isComplete;
            todo.name = item.name;
            context.TodoItems.Update(item);
            try
            {
                context.SaveChangesAsync();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
            return new NoContentResult();
        }
        [HttpDeleteAttribute("{id}")]
        public IActionResult delItem(int id){
            if(context.TodoItems.FirstOrDefault(x=>x.id==id)==null){
                return NotFound();
            }
            context.TodoItems.Remove(context.TodoItems.FirstOrDefault(x => x.id == id));
            context.SaveChanges();
            return new NoContentResult();
        }
    }
}