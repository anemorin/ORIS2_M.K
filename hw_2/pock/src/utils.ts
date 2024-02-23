export const toUpperCase = (word : string) : string => {
  return word.charAt(0).toUpperCase() + word.slice(1);
};

export const toId = (id : string) : string => {
  switch (id.toString.length) {
    case 1:
      return `#00${id}`;
    case 2:
      return `#0${id}`;
    default:
      return `#${id}`;
  }
}

export const getFoots = (sm : number) => {
  const foots = Math.floor(sm * 10 / 30.48);
  const inchs = Math.floor(((sm * 10 / 30.48) - foots) * 12);
  return `${foots}'${inchs}''`
}

export const getIbs = (kg: number) => {
  const ibs = Math.floor(kg * 2.20462);
  return `${ibs} ibs`
}