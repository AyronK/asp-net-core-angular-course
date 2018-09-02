import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'propertiesArray'
})
export class PropertiesArrayPipe implements PipeTransform {

  transform(value: any, args?: any): any {
    if (value) {
      return Object.keys(value);
    }
  }

}
