import './App.css';
import React, { useEffect, useState } from 'react';
import axios from 'axios';

const App = () => {
    const [items, setItems] = useState([]);
    const [units, setUnits] = useState([]);
    const [itemUnits, setItemUnits] = useState([]);
  
    
    useEffect(() => {
      const fetchItems = async () => {
        try {
          const response = await fetch('http://localhost:44391/api/items');
          const data = await response.json();
          setItems(data); 
        } catch (error) {
          console.error('Error fetching Items:', error);
        }
      };
  
      fetchItems();
    }, []);
  
   
    useEffect(() => {
      const fetchUnits = async () => {
        try {
          const response = await fetch('http://localhost:44391/api/units');
          const data = await response.json();
          setUnits(data); 
        } catch (error) {
          console.error('Error fetching Units:', error);
        }
      };
  
      fetchUnits();
    }, []);
  
    
    useEffect(() => {
      const fetchItemUnits = async () => {
        try {
          const response = await fetch('http://localhost:44391/api/itemsUnits');
          const data = await response.json();
          setItemUnits(data); 
        } catch (error) {
          console.error('Error fetching Item_Unit:', error);
        }
      };
  
      fetchItemUnits();
    }, []);
  
    
    const mergedData = itemUnits.map(itemUnit => {
      const item = items.find(item => item.id === itemUnit.idItem);
      const unit = units.find(unit => unit.id === itemUnit.idUnit);
      return {
        ...item,
        unitName: unit.name,
        price: itemUnit.price
      };
    });
  
    const handleQtyChange = (itemId, newQty) => {
        const updatedItems = items.map(item =>
          item.id === itemId ? { ...item, qty: Math.max(newQty, 0) } : item
        );
        setItems(updatedItems);
      };
      
    return (
      <div>
        <table>
          <thead>
            <tr>
              <th>Item Code</th>
              <th>Item Name</th>
              <th>Unit</th>
              <th>QTY</th>
              <th>Price</th>
              <th>Total</th>
            </tr>
          </thead>
          <tbody>
            {mergedData.map(item => (
              <tr key={item.id}>
                <td>{item.code}</td>
                <td>{item.name}</td>
                <td>{item.unitName}</td>
                <td>
                <input
                  type="number"
                  value={item.qty}
                  onChange={e => handleQtyChange(item.id, parseFloat(e.target.value))}
                  min={0}
                  step={0.1}
                />
              </td>
              <td>{item.price}</td>
              <td>{(item.qty * item.price).toFixed(2)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    );
  };



export default App;
