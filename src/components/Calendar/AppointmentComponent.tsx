import React from 'react';
import 'react-big-calendar/lib/css/react-big-calendar.css';
import { Accordion, Button, Table } from 'react-bootstrap';
import { addDays, addHours, daysOfWeek, getDayFromDate } from '../../helpers/DateHelper';
import { CalendarEvent } from '../../types/Calendar/CalendarEvent';


interface AppointmentSelectorProps {
  events: CalendarEvent[];
  currentDate: Date;
  activeAccordian: string | null;
  onAddAppointment: (date: Date) => void;
  onAccordionToggle: () => void;
}

interface AppointmentButtonComponentProps {
  day: Date;
}

const AppointmentComponent: React.FC<AppointmentSelectorProps> = ({ events, currentDate, activeAccordian, onAddAppointment, onAccordionToggle }) => {


  const handleAppointmentClick = (date: Date) => {

    onAddAppointment(date);
    onAccordionToggle();
  }

  const generateTableHeaders = () => {

    const headers = [];
      for (let i = 0; i < 7; i++) {
        const dayIndex = (currentDate.getDay() + i) % 7; // Wrap around to start from 0 after Saturday

        const _date = addDays(currentDate, i);
        const _day = getDayFromDate(_date);

        headers.push(<th key={daysOfWeek[dayIndex]}>{daysOfWeek[dayIndex]} {_day}</th>);
      }
    return headers;
  }

  const generateTableBody = () => {

    const body = [];
      for (let i = 0; i < 7; i++) {
        const dayIndex = (currentDate.getDay() + i) % 7; // Wrap around to start from 0 after Saturday

        var searchDate = addDays(currentDate, i);

        let availableSlots = generateAppointmentSchedulesButtons(searchDate);
        let slotsRow = (
        <th key={daysOfWeek[dayIndex]}>
          {availableSlots.map((slot) => 
          {
            return ({...slot})
          })}
        </th>);

        body.push(slotsRow);
      }

    return body;
  }

  const generateAppointmentSchedulesButtons = (date: Date) => {

    var buttons = [];

    for (let index = 0; index < 8; index++) {
      buttons.push(<AppointmentButtonComponent day={addHours(date, index)} />);
    }

    return buttons;
  }

  const AppointmentButtonComponent: React.FC<AppointmentButtonComponentProps> = (props) => {

    var date = props.day;
    var dayIndex = date.getDay();

    var start = date.getHours();

    var startString = `${start}:00`;

    var end = start += 1;

    var endString = `${end}:00`;

    var dateExist = events.findIndex(e => e.start?.getTime() === date.getTime());

    if((date < new Date) || dayIndex === 0 || dayIndex === 6 || dateExist > -1){
      return (<Button className='appointment-occupied-btn'>-</Button>)
    }else{
      return (<Button onClick={() => handleAppointmentClick(date)} className='appointment-btn'>{startString} - {endString}</Button>)
    }
  }

  return (
    <div className="rbc-toolbar">
        <Accordion activeKey={activeAccordian}>
            <Accordion.Item eventKey="appointments">
              <Accordion.Header onClick={onAccordionToggle}>
                Find appointment
              </Accordion.Header>
              <Accordion.Body>
                <Table responsive>
                  <thead>
                    <tr>
                      {generateTableHeaders()}
                      <th></th>
                    </tr>
                  </thead>
                  <tbody>
                    {generateTableBody()}
                  </tbody>
                </Table>
              </Accordion.Body>
            </Accordion.Item>
          </Accordion>
  </div>
  );
};

export default AppointmentComponent;


