import { CalendarEvent } from "../../types/Calendar/CalendarEvent";

export const sampleEvents: CalendarEvent[] = [
    {
      title: 'Meeting',
      start: new Date(2023, 6, 10, 10, 0, 0),
      end: new Date(2023, 6, 10, 11, 0, 0),
      color: '#f56b00', // Custom color for this event
      borderColor: '#000000', // Custom border color for this event
      description: 'Discuss project status and next steps.', // Additional property
    },
    {
      title: 'Lunch Break',
      start: new Date(2023, 6, 10, 12, 0, 0),
      end: new Date(2023, 6, 10, 13, 0, 0),
      color: '#3a87ad', // Custom color for this event
      borderColor: '#FFFFFF', // Custom border color for this event
      description: 'Relax and have lunch.', // Additional property
    },
  ];



  export const sampleAvailableEvents: CalendarEvent[] = [
    {
      title: 'Meeting',
      start: new Date(2023, 6, 10, 10, 0, 0),
      end: new Date(2023, 6, 10, 11, 0, 0),
      color: '#f56b00', // Custom color for this event
      borderColor: '#000000', // Custom border color for this event
      description: 'Discuss project status and next steps.', // Additional property
    },
  ];

