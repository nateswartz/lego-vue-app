import CounterExample from 'components/counter-example'
import LegoSets from 'components/lego-sets'
import HomePage from 'components/home-page'
import SetParts from 'components/set-parts'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home icon' },
  { name: 'counter', path: '/counter', component: CounterExample, display: 'Counter', icon: 'graduation cap icon' },
  { name: 'lego-sets', path: '/lego-sets', component: LegoSets, display: 'Lego Sets', icon: 'list icon' },
  { name: 'set-parts', path: '/set-parts', component: SetParts, display: 'Set Parts', icon: 'puzzle piece icon' }
]
