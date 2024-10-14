import { ChangeEvent, useEffect, useState } from 'react'
import { Button, Form, Tab, Tabs } from 'react-bootstrap';
import { useParams, useNavigate } from 'react-router-dom';
import { CaseRequest } from '../../types/Case/CaseRequest';
import { deleteCaseById, getCaseById, postCase } from '../../functions/fetchEntities';
import Loading from '../HelperComponents/Loading';
import { NavigateAction, View } from 'react-big-calendar';
import CalendarComponent from '../Calendar/CalendarComponent';
import moment from 'moment';
import { CalendarEvent } from '../../types/Calendar/CalendarEvent';
import { addHours } from '../../helpers/DateHelper';
import FilesComponent from './FilesComponent';

function EditCase() {

    // const state = useSelector((state: RootState) => state.systemUser);

    // // const systemUser = state.systemUser;


    // const getTabKeyFromHash = (hash: string) => {
    //     var key = hash.replace('#', '') || "Case Details";

    //     return key;
    //   };


    const [hasBeenEdited, setHasBeenEdited] = useState(false);
    const [validated, setValidated] = useState(false);

    const [selectedCase, setSelectedCase] = useState<CaseRequest>({} as CaseRequest);
    const [currentDate, setCurrentDate] = useState(new Date());

    const [currentView, setCurrentView] = useState<View>('day');
    const [activeAccordian, setActiveAccordian] = useState<string | null>(null);

    const [calendarEvents, setCalendarEvents] = useState<CalendarEvent[]>([]);

    // const [activeKey, setActiveKey] = useState<string>(getTabKeyFromHash(location.hash));

    const navigate = useNavigate();

    const { id } = useParams();
    const parsedId = id !== undefined ? id : "";

    useEffect(() => {

        if (parsedId !== "new") {
            getCaseById(parsedId)
                .then((data) => setSelectedCase(data));
        }

    }, [parsedId]);

    const handleNavigate = (action: NavigateAction) => {

        const viewToUnitsMap: Record<string, moment.unitOfTime.DurationConstructor> = {
        day: 'day',
        week: 'week',
        month: 'month',
        };
        
        let units = viewToUnitsMap[currentView.toString()] || 'week';

        switch (action) {
            case 'PREV':
                setCurrentDate(moment(currentDate).subtract(1, units).toDate()); // Example: Move back one month
                break;
            case 'NEXT':
                setCurrentDate(moment(currentDate).add(1, units).toDate()); // Example: Move forward one month
                break;
            default:
                setCurrentDate(new Date()); // Set current date to today
                break;
        }
    };

    const handleTitleChange = (event: ChangeEvent<HTMLInputElement>) => {
        const title = event.target.value;
        setSelectedCase({...selectedCase, title: title});
        setHasBeenEdited(true);
    }

    const handleDelete = async (event:any) => {
        event.preventDefault();


        if(window.confirm(`Are you sure you want to delete ${selectedCase.title}`))
        {
            await deleteCaseById(selectedCase.id);
            navigate('/Cases', {replace: true});
        };

    };

    const handleSubmit = async (event:any) => {
        const form = event.currentTarget;
        event.preventDefault();
    
        if (form.checkValidity() === false) {
          event.stopPropagation();
        }else{
            if (hasBeenEdited) {
                // selectedStudent.updatedBy = systemUser.displayName;
                await postCase(selectedCase);
            }
            navigate('/Cases', {replace: true});
        }
        setValidated(true);
    };

    const onAddAppointment = (date: Date) => {

        var newEvent: CalendarEvent = {
            title: selectedCase.title,
            start: date,
            end: addHours(date, 1)
        }

        setCalendarEvents([...calendarEvents, newEvent]);
    }

    const onAccordionToggle = () => {

        const newState = activeAccordian !== "appointments" ? "appointments" : null;
        setActiveAccordian(newState);
    }


    return (
        <>
            {parsedId === "new" || selectedCase.id !== undefined ? 
                <div className='page'>
                    <h1>Edit Case</h1>
                    <Form noValidate validated={validated} onSubmit={event => handleSubmit(event)}>

                        <div className='edit-action-btns'>
                            <Button id="save" className='edit-form-submit' variant="primary" type="submit">
                                Save
                            </Button>
                                
                            {parsedId !== "new" && 
                            (
                                <Button id="save" className='edit-form-submit' variant="danger" onClick={handleDelete} >
                                    Delete
                                </Button>
                            )}
                        </div>

                        <Tabs defaultActiveKey={"Case Details"} className="mb-3">
                            <Tab eventKey="Case Details" title="Case Details">
                                <Form.Group className="mb-3">
                                    <Form.Label>Case Title</Form.Label>
                                    <Form.Control 
                                    id="edit-name"
                                    type="text" 
                                    placeholder="Case Title" 
                                    onChange={handleTitleChange} 
                                    value={selectedCase.title} 
                                    required
                                    />
                                </Form.Group>
                            </Tab>
                            <Tab eventKey="Schedule Hearing" title="Schedule Hearing">
                                <CalendarComponent 
                                    currentView={currentView} 
                                    events={calendarEvents} 
                                    onNavigate={handleNavigate} 
                                    onView={setCurrentView}
                                    onAddAppointment={onAddAppointment} 
                                    currentDate={currentDate} 
                                    activeAccordian={activeAccordian}
                                    onAccordionToggle={onAccordionToggle}
                                    />
                            </Tab>
                            <Tab eventKey="Documents" title="Documents">
                                <FilesComponent caseId={selectedCase.id} />
                            </Tab>
                        </Tabs>
                    </Form>
                </div> 
                : 
                <Loading /> 
            }
        </>
  )
}

export default EditCase;