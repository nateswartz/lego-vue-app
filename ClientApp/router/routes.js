import LegoSets from 'components/lego-sets'
import HomePage from 'components/home-page'
import SetParts from 'components/set-parts'

export const routes = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home icon' },
  { name: 'lego-sets', path: '/lego-sets', component: LegoSets, display: 'Lego Sets', icon: 'list icon' },
  { name: 'set-parts', path: '/set-parts', component: SetParts, display: 'Set Parts', icon: 'puzzle piece icon', props: (route) => { initialSetID: route.query.setid } },
  { name: 'set-parts-with-id', path: '/set-parts/:initialSetID', component: SetParts, display: 'Set Parts', icon: 'question icon', props: true }
]

export const routesForMenu = [
  { name: 'home', path: '/', component: HomePage, display: 'Home', icon: 'home icon' },
  { name: 'lego-sets', path: '/lego-sets', component: LegoSets, display: 'Lego Sets', icon: 'list icon' },
  { name: 'set-parts', path: '/set-parts', component: SetParts, display: 'Set Parts', icon: 'puzzle piece icon', props: (route) => { initialSetID: route.query.setid } },
]
