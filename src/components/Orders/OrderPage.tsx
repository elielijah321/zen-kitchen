import { Tab, Tabs } from "react-bootstrap";
import OrderComponent from "./Order/OrderComponent";
import ShoppingComponent from "./Shopping/ShoppingComponent";

function OrderPage() {

  return (
    <>
      <div className='page'>
        <Tabs defaultActiveKey={"Orders"} className="mb-3">
          <Tab eventKey="Orders" title="Orders">
            <OrderComponent />
          </Tab>
          <Tab eventKey="Shopping List" title="Shopping List">
            <ShoppingComponent />
          </Tab>


        </Tabs>
      </div>
    </>
  )
}

export default OrderPage;