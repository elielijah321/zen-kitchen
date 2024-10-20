import { Tab, Tabs } from "react-bootstrap";
import OrderComponent from "./OrderComponent";

function OrderPage() {

  return (
    <>
      <div className='page'>
        <Tabs defaultActiveKey={"Orders"} className="mb-3">
          <Tab eventKey="Orders" title="Orders">
            <OrderComponent />
          </Tab>


        </Tabs>
      </div>
    </>
  )
}

export default OrderPage;