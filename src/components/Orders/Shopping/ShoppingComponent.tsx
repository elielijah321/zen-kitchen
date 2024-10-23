import { useEffect, useState } from 'react'
import { Accordion, Table } from 'react-bootstrap';
import { Order } from '../../../types/Order/Order';
import Loading from '../../HelperComponents/Loading';
import { getAllOrders } from '../../../functions/fetchEntities';
import { ShoppingListItem } from '../../../types/Ingredient/Ingredient';

function ShoppingComponent() {

  // const state = useSelector((state: RootState) => state.systemUser);
  // const systemUser = state.systemUser;

  const [orders, setOrders] = useState<Order[]>();
  const [shoppingList, setShoppingList] = useState<ShoppingListItem[]>([]); 

  useEffect(() => {
    // fetch data
    getAllOrders()
       .then(orders => {


        setOrders(orders);
        setShoppingList(getShoppingList(orders));
       });

  }, []);


  const getAllIngredients = (orders: Order[]) => {

    let ingredients = orders
      .flatMap(order => 
        order.orderDetails.flatMap(recipe => 
          recipe.ingredients.map(ingredient => {
            return ingredient.ingredient!;
          })
        )
      );

      return ingredients;
  } 


  const getShoppingList = (orders: Order[]) => {

    let ingredientMap = new Map<string, ShoppingListItem>();
    var ingredients = getAllIngredients(orders);

   ingredients.forEach(ingredient => {
          const { name, weight, unitOfMeasurement } = ingredient;
    
          if (ingredientMap.has(name)) {
            // If the ingredient is already in the map, update the quantity and total amount needed
            const existingItem = ingredientMap.get(name)!;
            existingItem.quantity += 1;
            existingItem.totalAmountNeeded += weight;
          } else {
            // If it's a new ingredient, add it to the map
            ingredientMap.set(name, {
              ingredientName: name,
              quantity: 1,
              totalAmountNeeded: weight,
              unitOfMeasurement: unitOfMeasurement
            });
          }
        });
    
    // Convert the Map to an array of ShoppingListItem objects
    let shoppingList: ShoppingListItem[] = Array.from(ingredientMap.values());

    return shoppingList;
  }

  const calculateWeightMeasurement = (shoppingListItem: ShoppingListItem) => {

    var totalAmountNeeded = shoppingListItem.totalAmountNeeded;
    var uom = shoppingListItem.unitOfMeasurement;

    if (totalAmountNeeded < 1000) {
      return `${totalAmountNeeded}${uom}`;
    }else{

      var newTotal = (totalAmountNeeded / 1000).toFixed(1);

      return `${newTotal}${uom === "g" ? "kg" : "l"}`;
    }
  }

  return (
    <>
      <div>
        
        {orders !== undefined ?
        (
          <div>
            <Accordion defaultActiveKey={"shopping"}>
                <Accordion.Item key={"shopping"} eventKey={"shopping"}>
                        <Accordion.Header>{"Shopping"}</Accordion.Header>
                        <Accordion.Body>
                          {
                          shoppingList.length > 0 ? 
                          <div>
                            <Table striped hover responsive>
                              <thead>
                                <th>Name</th>
                                <th>Quantity</th>
                                <th>Total Weight</th>
                              </thead>
                              <tbody>
                                {
                                  shoppingList.map(i => {

                                    return(
                                      <tr>
                                        <td>{i.ingredientName}</td>
                                        <td>{i.quantity}</td>
                                        <td>{calculateWeightMeasurement(i)}</td>
                                      </tr>
                                    )
                                  })
                                }
                              </tbody>
                            </Table>
                          </div> : <div>No orders</div>
                          }
                        </Accordion.Body>
                </Accordion.Item>
            </Accordion>
          </div> 
        )
        : <Loading /> }

      </div>
    </>
  )
}

export default ShoppingComponent;