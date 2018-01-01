import { Component, ViewChild } from "@angular/core"
import { util, ViewModel,QueryParameter, TableWrapperComponent, HttpContentType } from "../../util";

@Component({
    selector: 'demo',
    templateUrl: '/Home/Demo'
})
export class DemoComponent {
    queryParam: CustomerQueryModel;

    @ViewChild('grid') grid: TableWrapperComponent<CustomerViewModel>;

    model: CustomerViewModel;

    delete() {
        this.grid.delete();
    }

    constructor() {
        this.queryParam = new CustomerQueryModel();
        this.model = new CustomerViewModel();
    }

    query() {
        this.grid.query();
    }

    data = [
        { value: '1', viewValue: '哈哈' },
        { value: '2', viewValue: '嘿嘿', disabled: true },
        { value: '3', viewValue: 'C3333333333333' },
        { value: '4', viewValue: 'D34444444444444444444' },
        { value: '5', viewValue: 'E55555555555555' },
        { value: '6', viewValue: 'F666666666666' },
        { value: '7', viewValue: 'G777777777' },
        { value: '8', viewValue: 'H7777777777' },
        { value: '9', viewValue: 'I8888888888888' }
    ];

    foods = [
        { value: '1', viewValue: 'A11111111111111111' },
        { value: '2', viewValue: 'B1122222222222222222', disabled: true },
        { value: '3', viewValue: 'C3333333333333' },
        { value: '4', viewValue: 'D34444444444444444444' },
        { value: '5', viewValue: 'E55555555555555'},
        { value: '6', viewValue: 'F666666666666'},
        { value: '7', viewValue: 'G777777777'},
        { value: '8', viewValue: 'H7777777777'},
        { value: '9', viewValue: 'I8888888888888'}
    ];

    pokemonGroups = [
        {
            name: 'Grass',
            pokemon: [
                { value: 'bulbasaur-0', viewValue: 'Bulbasaur' },
                { value: 'oddish-1', viewValue: 'Oddish' },
                { value: 'bellsprout-2', viewValue: 'Bellsprout' }
            ]
        },
        {
            name: 'Water',
            pokemon: [
                { value: 'squirtle-3', viewValue: 'Squirtle' },
                { value: 'psyduck-4', viewValue: 'Psyduck' },
                { value: 'horsea-5', viewValue: 'Horsea' }
            ]
        },
        {
            name: 'Fire',
            disabled: true,
            pokemon: [
                { value: 'charmander-6', viewValue: 'Charmander' },
                { value: 'vulpix-7', viewValue: 'Vulpix' },
                { value: 'flareon-8', viewValue: 'Flareon' }
            ]
        },
        {
            name: 'Psychic',
            pokemon: [
                { value: 'mew-9', viewValue: 'Mew' },
                { value: 'mewtwo-10', viewValue: 'Mewtwo' },
            ]
        }
    ];
}


class CustomerQueryModel extends QueryParameter {
    public name: string;
}

class CustomerViewModel extends ViewModel {
    public name: string;
    public value: string;
    public a:string;
}