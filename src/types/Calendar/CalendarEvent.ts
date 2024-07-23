import { Event } from 'react-big-calendar';

export interface CalendarEvent extends Event {
    color?: string;
    borderColor?: string;
    description?: string;
  }