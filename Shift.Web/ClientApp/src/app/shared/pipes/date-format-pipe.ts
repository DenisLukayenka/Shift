import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'dateFormat',
})
export class DateFormatPipe implements PipeTransform {
    transform(date: string | Date, timeFormat: string = '') {
        const defaultValues = {
            dateFormat: 'dd-MM-yyyy',
            language: 'ru-RU',
            timeZone: 'GMT+3',
        };
        
    }
}