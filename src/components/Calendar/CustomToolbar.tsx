import React from 'react';
import { ToolbarProps, NavigateAction, View } from 'react-big-calendar';
import './Calendar.css';
import AppointmentComponent from './AppointmentComponent';
import { CalendarEvent } from '../../types/Calendar/CalendarEvent';

interface CustomToolbarProps extends ToolbarProps {
  onNavigateCustom: (action: NavigateAction) => void;
  onViewCustom: (view: View) => void;
  onAddAppointment: (date: Date) => void;
  events: CalendarEvent[];
  currentDate: Date;
  activeAccordian: string | null;
  onAccordionToggle: () => void;
}

const CustomToolbar: React.FC<CustomToolbarProps> = (props) => {

  const handleNavigate = (action: NavigateAction) => {
    props.onNavigate(action); // Default behavior
    props.onNavigateCustom(action); // Custom behavior from parent

  };

  const handleViewChange = (view: View) => {
    props.onView(view); // Default behavior
    props.onViewCustom(view); // Custom behavior from parent
    // Preserve the expanded state if needed, currently it doesn't change the state

  };

  return (
    <>
      <div className="rbc-toolbar">
        <span className="rbc-btn-group">
          <button type="button" onClick={() => handleViewChange('day')}>Day</button>
          <button type="button" onClick={() => handleViewChange('week')}>Week</button>
          <button type="button" onClick={() => handleViewChange('month')}>Month</button>
        </span>
        <span className="rbc-toolbar-label">
          {props.label}
        </span>
        <span className="rbc-btn-group">
          {/* <button type="button" onClick={() => handleNavigate('TODAY')}>Today</button> */}
          <button type="button" onClick={() => handleNavigate('PREV')}>Back</button>
          <button type="button" onClick={() => handleNavigate('NEXT')}>Next</button>
        </span>
      </div>


      <AppointmentComponent 
          onAddAppointment={props.onAddAppointment} 
          currentDate={props.currentDate} 
          activeAccordian={props.activeAccordian} 
          events={props.events} 
          onAccordionToggle={props.onAccordionToggle}
        />

    </>
  );
};

export default CustomToolbar;
