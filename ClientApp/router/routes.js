import CounterExample from 'components/counter-example'
import FetchData from 'components/fetch-data'
import LegoSets from 'components/lego-sets'
import HomePage from 'components/home-page'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home' },
  { name: 'counter', path: '/counter', component: CounterExample, display: 'Counter', icon: 'graduation-cap' },
  { name: 'fetch-data', path: '/fetch-data', component: FetchData, display: 'Fetch data', icon: 'list icon' },
  { name: 'lego-sets', path: '/lego-sets', component: LegoSets, display: 'Lego Sets', icon: 'list icon' }
]
