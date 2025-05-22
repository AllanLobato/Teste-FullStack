import { NavLink } from 'react-router-dom';

export default function Tabs() {
  const baseClasses = 'w-1/2 text-center px-6 py-3 text-sm font-medium';
  const activeClass =
    'text-orange-500 border-b-2 border-orange-500 bg-white';
  const inactiveClass = 'text-gray-500 hover:text-orange-500 bg-white';

  return (
    <div className="flex justify-center p-4 bg-gray-100 border-gray-300">
      <NavLink
        to="/invited"
        className={({ isActive }) =>
          `${baseClasses} ${isActive ? activeClass : inactiveClass}`
        }
      >
        Invited
      </NavLink>
      <NavLink
        to="/accepted"
        className={({ isActive }) =>
          `${baseClasses} ${isActive ? activeClass : inactiveClass}`
        }
      >
        Accepted
      </NavLink>
    </div>
  );
}
