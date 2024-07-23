
export const getDisplayDate = (date?: Date) => {

    var formattedDate = date ? new Date(date).toLocaleString("en-GB").split(", ")[0] : "";
    return formattedDate;
}


export const getCalendarDate = (date?: Date) => {

    var formattedDate = getDisplayDate(date);
    var calendarDate = formattedDate !== "" ? formattedDate = formattedDate.split("/").reverse().join("-") : "";

    return calendarDate;
}

export const getDayOfTheWeek = (date: Date) => {

    const days = ['SUN', 'MON', 'TUE', 'WED', 'THUR', 'FRI', 'SAT'];

    return days[ date.getDay() ];
}

export const dateIsInThePast = (date: Date) => {

    var today = new Date();
    var dateToCheck = new Date(date);

    const result = today > dateToCheck;

    return result;
}

export const daysOfWeek = ['SUN', 'MON', 'TUE', 'WED', 'THUR', 'FRI', 'SAT'];

export const addDays = (date: Date, days: number) => {
    var result = new Date(date);
    result.setDate(result.getDate() + days);
    result.setHours(9);
    result.setMinutes(0);
    result.setSeconds(0);
    return result;
  }

  export const addHours = (date: Date, hours: number) => {
    var result = new Date(date);
    result.setHours(result.getHours() + hours);
    return result;
  }


export const getDayFromDate = (date: Date) => {

    return getCalendarDate(date).split('-')[2]
}

export const dateTimeTryParse = (dateString: string): boolean => {
    // Split the date string into year, month, and day
    const [year, month, day] = dateString.split('-');

    // Create a new Date object with the parsed values
    const parsedDate = new Date(Number(year), Number(month) - 1, Number(day));

    // Check if the parsing was successful
    if (isNaN(parsedDate.getTime())) {
      // Parsing failed, return null or throw an error
      return false;
    }else{
        return true;
    }
}

export const minDate = getCalendarDate(new Date(2022, 12, 1));

const getTomorrow = () => {
    var tomorrow = new Date();
    tomorrow.setDate(new Date().getDate());
    return getCalendarDate(tomorrow);
}

export const maxDate = getTomorrow();



export const disableTyping = (e: any) => {

    const disableTyping = false;

    if (disableTyping) {
         e.preventDefault();
    }

}

