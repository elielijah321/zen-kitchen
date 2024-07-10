
export const getDisplayDate = (date?: Date) => {

    var formattedDate = date ? new Date(date).toLocaleString("en-GB").split(", ")[0] : "";
    return formattedDate;
}


export const getCalendarDate = (date?: Date) => {

    var formattedDate = getDisplayDate(date);
    var calendarDate = formattedDate !== "" ? formattedDate = formattedDate.split("/").reverse().join("-") : "";

    return calendarDate;
}

export const dateIsInThePast = (date: Date) => {

    var today = new Date();
    var dateToCheck = new Date(date);

    const result = today > dateToCheck;

    return result;
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

