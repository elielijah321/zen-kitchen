import React from 'react';
import { Calendar, momentLocalizer, View, NavigateAction } from 'react-big-calendar';
import moment from 'moment';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import CustomToolbar from './CustomToolbar'; // Import your custom toolbar
import { CalendarEvent } from '../../types/Calendar/CalendarEvent';

interface CalendarComponentProps {
  events: CalendarEvent[];
  onNavigate: (action: NavigateAction) => void;
  onView: (view: View) => void;
  onAddAppointment: (date: Date) => void;
  currentView: View;
  currentDate: Date;
  activeAccordian: string | null;
  onAccordionToggle: () => void;
}

const localizer = momentLocalizer(moment);

const CalendarComponent: React.FC<CalendarComponentProps> = ({ events, onNavigate, onView, onAddAppointment, currentView, currentDate, activeAccordian, onAccordionToggle }) => {

  const eventPropGetter = (event: CalendarEvent) => {
    const backgroundColor = event.color || '#3174ad'; // Default color if not specified
    const borderColor = event.borderColor || '#000'; // Default border color if not specified
    return {
      style: { backgroundColor, borderColor },
    };
  };

  const handleEventClick = (event: CalendarEvent) => {
    alert(`Event: ${event.title}\nDescription: ${event.description}`);
  };

  return (
    <div>
      <Calendar
        localizer={localizer}
        events={events}
        startAccessor="start"
        endAccessor="end"
        views={[ 'day', 'week', 'month']}
        defaultView="day"
        view={currentView}
        style={{ height: 500 }}
        min={new Date(1970, 1, 1, 9, 0, 0)} // 9:00 AM
        max={new Date(1970, 1, 1, 17, 0, 0)} // 5:00 PM
        eventPropGetter={eventPropGetter}
        onSelectEvent={handleEventClick}
        components={{
          toolbar: (props) => (
            <CustomToolbar
              {...props}
              onNavigateCustom={onNavigate}
              onViewCustom={onView}
              onAddAppointment={onAddAppointment}
              events={events}
              currentDate={currentDate}
              activeAccordian={activeAccordian}
              onAccordionToggle={onAccordionToggle}
            />
          ),
        }}
      />
    </div>
  );
};

export default CalendarComponent;


