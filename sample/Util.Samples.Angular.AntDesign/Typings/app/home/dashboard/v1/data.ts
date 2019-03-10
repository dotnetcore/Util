export const data = [
  { country: 'Europe', year: '1750', value: 163 },
  { country: 'Europe', year: '1800', value: 203 },
  { country: 'Europe', year: '1850', value: 276 },
  { country: 'Europe', year: '1900', value: 408 },
  { country: 'Europe', year: '1950', value: 547 },
  { country: 'Europe', year: '1999', value: 729 },
  { country: 'Europe', year: '2050', value: 628 },
  { country: 'Europe', year: '2100', value: 828 },
  { country: 'Asia', year: '1750', value: 502 },
  { country: 'Asia', year: '1800', value: 635 },
  { country: 'Asia', year: '1850', value: 809 },
  { country: 'Asia', year: '1900', value: 947 },
  { country: 'Asia', year: '1950', value: 1402 },
  { country: 'Asia', year: '1999', value: 3634 },
  { country: 'Asia', year: '2050', value: 5268 },
  { country: 'Asia', year: '2100', value: 7268 }
];

export const data1 = {
  'country': ['Europe', 'Europe', 'Europe', 'Asia', 'Asia', 'Asia'],
  'year': ['1750', '1800', '1850', '1750', '1800', '1850'],
  'value': [163, 203, 276, 502, 635, 809],
};

export const data2 = [
  ['country', 'Europe', 'Europe', 'Europe', 'Asia', 'Asia', 'Asia'],
  ['year', '1750', '1800', '1850', '1750', '1800', '1850'],
  ['value', 163, 203, 276, 502, 635, 809],
];

export const data3 = [
  ['Europe', 'Europe', 'Europe', 'Europe', 'Europe', 'Europe', 'Europe', 'Europe', 'Asia', 'Asia', 'Asia', 'Asia', 'Asia', 'Asia', 'Asia', 'Asia'],
  ['1750', '1800', '1850', '1900', '1950', '1999', '2050', '2100', '1750', '1800', '1850', '1900', '1950', '1999', '2050', '2100'],
  [163, 203, 276, 408, 547, 729, 628, 828, 502, 635, 809, 947, 1402, 3634, 5268, 7268],
];

export const scale = [{
  dataKey: 'percent',
  min: 0,
  formatter: '.2%',
}];
