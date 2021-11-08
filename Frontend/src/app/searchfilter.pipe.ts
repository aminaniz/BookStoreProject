import { Pipe, PipeTransform } from '@angular/core';
import { book } from 'src/app/book';

@Pipe({
  name: 'searchfilter'
})
export class SearchfilterPipe implements PipeTransform {

  transform(Books: book[], Title:string): book[] {
    if(!Books || !Title){
      return Books;
    }
    return Books.filter(res=>
      res.Title.toLocaleLowerCase().includes(Title.toLocaleLowerCase())
      );
  }

}
