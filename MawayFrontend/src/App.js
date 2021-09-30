import React from 'react';
import ReservationContainer from './modules/reservation-main/components/stepsContainer';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faCog, faSnowflake, faCheck, faTimes, faGasPump, faDoorOpen, faCoins, faShoppingCart } from '@fortawesome/free-solid-svg-icons';
import { fab } from '@fortawesome/free-brands-svg-icons';
library.add(fab, faCog,faSnowflake, faCheck, faTimes, faGasPump, faDoorOpen, faCoins,faShoppingCart)

function App() {
  return (
      <ReservationContainer />
  );
}


export default App;


