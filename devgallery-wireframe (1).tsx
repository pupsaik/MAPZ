import React, { useState } from 'react';
import { User, Search, ShoppingCart, Heart, MessageCircle, Settings, Bell, Star, Upload, BarChart3, Shield, CreditCard, Filter, Eye, Download, FileText } from 'lucide-react';

const DevGalleryWireframe = () => {
  const [currentPage, setCurrentPage] = useState('home');
  const [userRole, setUserRole] = useState('buyer'); // buyer, seller, admin
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  // Mock data
  const projects = [
    { id: 1, title: 'E-commerce Platform', price: '$299', rating: 4.8, tech: ['React', 'Node.js'], category: 'Web App' },
    { id: 2, title: 'Mobile Banking App', price: '$499', rating: 4.9, tech: ['React Native', 'Firebase'], category: 'Mobile' },
    { id: 3, title: 'Analytics Dashboard', price: '$199', rating: 4.7, tech: ['Vue.js', 'D3.js'], category: 'Dashboard' },
  ];

  const Header = () => (
    <div className="bg-blue-600 text-white p-4 shadow-lg">
      <div className="flex justify-between items-center max-w-6xl mx-auto">
        <div className="flex items-center space-x-4">
          <h1 className="text-2xl font-bold cursor-pointer" onClick={() => setCurrentPage('home')}>
            DevGallery
          </h1>
          <nav className="hidden md:flex space-x-6">
            <button onClick={() => setCurrentPage('catalog')} className="hover:text-blue-200">Каталог</button>
            <button onClick={() => setCurrentPage('categories')} className="hover:text-blue-200">Категорії</button>
            {userRole === 'seller' && (
              <button onClick={() => setCurrentPage('my-projects')} className="hover:text-blue-200">Мої проекти</button>
            )}
            {userRole === 'admin' && (
              <button onClick={() => setCurrentPage('admin-panel')} className="hover:text-blue-200">Панель адміна</button>
            )}
          </nav>
        </div>
        
        <div className="flex items-center space-x-4">
          <Search className="w-5 h-5 cursor-pointer hover:text-blue-200" />
          <Bell className="w-5 h-5 cursor-pointer hover:text-blue-200" />
          {isLoggedIn ? (
            <div className="flex items-center space-x-2">
              <MessageCircle className="w-5 h-5 cursor-pointer hover:text-blue-200" />
              <Heart className="w-5 h-5 cursor-pointer hover:text-blue-200" />
              <ShoppingCart className="w-5 h-5 cursor-pointer hover:text-blue-200" />
              <div className="flex items-center space-x-2">
                <User className="w-5 h-5" />
                <select 
                  value={userRole} 
                  onChange={(e) => setUserRole(e.target.value)}
                  className="bg-blue-700 text-white rounded px-2 py-1 text-sm"
                >
                  <option value="buyer">Покупець</option>
                  <option value="seller">Продавець</option>
                  <option value="admin">Адмін</option>
                </select>
              </div>
              <button 
                onClick={() => setIsLoggedIn(false)}
                className="bg-blue-700 hover:bg-blue-800 px-3 py-1 rounded text-sm"
              >
                Вийти
              </button>
            </div>
          ) : (
            <button 
              onClick={() => setCurrentPage('auth')}
              className="bg-blue-700 hover:bg-blue-800 px-4 py-2 rounded"
            >
              Увійти
            </button>
          )}
        </div>
      </div>
    </div>
  );

  const HomePage = () => (
    <div className="space-y-8">
      <div className="bg-gradient-to-r from-blue-600 to-purple-600 text-white p-8 rounded-lg">
        <h2 className="text-3xl font-bold mb-4">Знайдіть ідеальне програмне рішення</h2>
        <p className="text-lg mb-6">AI-рекомендації • Демо-доступ • Персоналізація</p>
        <div className="flex space-x-4">
          <button 
            onClick={() => setCurrentPage('catalog')}
            className="bg-white text-blue-600 px-6 py-3 rounded-lg font-semibold hover:bg-gray-100"
          >
            Переглянути каталог
          </button>
          <button 
            onClick={() => setCurrentPage('auth')}
            className="border-2 border-white px-6 py-3 rounded-lg font-semibold hover:bg-white hover:text-blue-600"
          >
            Почати продавати
          </button>
        </div>
      </div>

      <div className="grid md:grid-cols-3 gap-6">
        <div className="bg-white p-6 rounded-lg shadow-md border">
          <h3 className="font-bold text-lg mb-3">🤖 AI-Рекомендації</h3>
          <p className="text-gray-600">Персоналізовані пропозиції на основі ваших потреб</p>
        </div>
        <div className="bg-white p-6 rounded-lg shadow-md border">
          <h3 className="font-bold text-lg mb-3">👀 Демо-доступ</h3>
          <p className="text-gray-600">Тестуйте проекти перед покупкою</p>
        </div>
        <div className="bg-white p-6 rounded-lg shadow-md border">
          <h3 className="font-bold text-lg mb-3">⚡ Швидка кастомізація</h3>
          <p className="text-gray-600">Запитайте адаптацію під ваші потреби</p>
        </div>
      </div>

      <div>
        <h3 className="text-2xl font-bold mb-6">Рекомендовані проекти</h3>
        <div className="grid md:grid-cols-3 gap-6">
          {projects.map(project => (
            <ProjectCard key={project.id} project={project} />
          ))}
        </div>
      </div>
    </div>
  );

  const ProjectCard = ({ project }) => (
    <div className="bg-white rounded-lg shadow-md border hover:shadow-lg transition-shadow">
      <div className="h-48 bg-gray-200 rounded-t-lg flex items-center justify-center">
        <span className="text-gray-500">Скріншот проекту</span>
      </div>
      <div className="p-4">
        <h4 className="font-bold text-lg mb-2">{project.title}</h4>
        <div className="flex items-center space-x-2 mb-2">
          <Star className="w-4 h-4 text-yellow-500" />
          <span className="text-sm text-gray-600">{project.rating}</span>
        </div>
        <div className="flex flex-wrap gap-1 mb-3">
          {project.tech.map(tech => (
            <span key={tech} className="bg-gray-100 text-gray-700 px-2 py-1 rounded text-xs">
              {tech}
            </span>
          ))}
        </div>
        <div className="flex justify-between items-center">
          <span className="font-bold text-blue-600">{project.price}</span>
          <div className="flex space-x-2">
            <Eye className="w-4 h-4 text-gray-500 cursor-pointer hover:text-gray-700" />
            <Heart className="w-4 h-4 text-gray-500 cursor-pointer hover:text-red-500" />
            <button 
              onClick={() => setCurrentPage('project-detail')}
              className="bg-blue-600 text-white px-3 py-1 rounded text-sm hover:bg-blue-700"
            >
              Детальніше
            </button>
          </div>
        </div>
      </div>
    </div>
  );

  const CatalogPage = () => (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h2 className="text-2xl font-bold">Каталог проектів</h2>
        <div className="flex space-x-4">
          <div className="flex items-center space-x-2">
            <Filter className="w-5 h-5" />
            <select className="border rounded px-3 py-2">
              <option>Всі категорії</option>
              <option>Web додатки</option>
              <option>Мобільні додатки</option>
              <option>Дашборди</option>
            </select>
          </div>
          <div className="flex items-center space-x-2">
            <Search className="w-5 h-5" />
            <input 
              type="text" 
              placeholder="Пошук проектів..." 
              className="border rounded px-3 py-2 w-64"
            />
          </div>
        </div>
      </div>

      <div className="grid md:grid-cols-4 gap-6">
        <div className="bg-white p-4 rounded-lg shadow-md border">
          <h3 className="font-bold mb-4">Фільтри</h3>
          <div className="space-y-4">
            <div>
              <label className="block text-sm font-medium mb-2">Ціна</label>
              <div className="space-y-2">
                <label className="flex items-center">
                  <input type="checkbox" className="mr-2" />
                  <span className="text-sm">До $100</span>
                </label>
                <label className="flex items-center">
                  <input type="checkbox" className="mr-2" />
                  <span className="text-sm">$100-$500</span>
                </label>
                <label className="flex items-center">
                  <input type="checkbox" className="mr-2" />
                  <span className="text-sm">$500+</span>
                </label>
              </div>
            </div>
            <div>
              <label className="block text-sm font-medium mb-2">Технології</label>
              <div className="space-y-2">
                <label className="flex items-center">
                  <input type="checkbox" className="mr-2" />
                  <span className="text-sm">React</span>
                </label>
                <label className="flex items-center">
                  <input type="checkbox" className="mr-2" />
                  <span className="text-sm">Vue.js</span>
                </label>
                <label className="flex items-center">
                  <input type="checkbox" className="mr-2" />
                  <span className="text-sm">Node.js</span>
                </label>
              </div>
            </div>
            <div>
              <label className="block text-sm font-medium mb-2">Рейтинг</label>
              <div className="space-y-2">
                <label className="flex items-center">
                  <input type="checkbox" className="mr-2" />
                  <span className="text-sm">4+ зірок</span>
                </label>
                <label className="flex items-center">
                  <input type="checkbox" className="mr-2" />
                  <span className="text-sm">3+ зірки</span>
                </label>
              </div>
            </div>
          </div>
        </div>

        <div className="md:col-span-3 grid md:grid-cols-2 lg:grid-cols-3 gap-6">
          {[...projects, ...projects, ...projects].map((project, index) => (
            <ProjectCard key={`${project.id}-${index}`} project={project} />
          ))}
        </div>
      </div>
    </div>
  );

  const ProjectDetailPage = () => (
    <div className="space-y-6">
      <div className="grid md:grid-cols-2 gap-8">
        <div>
          <div className="h-64 bg-gray-200 rounded-lg flex items-center justify-center mb-4">
            <span className="text-gray-500">Скріншот проекту</span>
          </div>
          <div className="grid grid-cols-3 gap-2">
            {[1, 2, 3].map(i => (
              <div key={i} className="h-20 bg-gray-100 rounded flex items-center justify-center">
                <span className="text-xs text-gray-500">Скрін {i}</span>
              </div>
            ))}
          </div>
        </div>

        <div className="space-y-6">
          <div>
            <h1 className="text-3xl font-bold mb-2">E-commerce Platform</h1>
            <div className="flex items-center space-x-4 mb-4">
              <div className="flex items-center">
                <Star className="w-5 h-5 text-yellow-500 mr-1" />
                <span>4.8 (124 відгуки)</span>
              </div>
              <span className="text-2xl font-bold text-blue-600">$299</span>
            </div>
            
            <div className="flex flex-wrap gap-2 mb-4">
              {['React', 'Node.js', 'MongoDB', 'Stripe'].map(tech => (
                <span key={tech} className="bg-blue-100 text-blue-800 px-3 py-1 rounded">
                  {tech}
                </span>
              ))}
            </div>

            <p className="text-gray-600 mb-6">
              Повнофункціональна платформа електронної комерції з адмін-панеллю, 
              системою оплати, управлінням товарами та аналітикою.
            </p>

            <div className="space-y-3">
              <button className="w-full bg-blue-600 text-white py-3 rounded-lg font-semibold hover:bg-blue-700">
                Купити зараз - $299
              </button>
              <div className="grid grid-cols-2 gap-3">
                <button className="border border-blue-600 text-blue-600 py-2 rounded-lg hover:bg-blue-50">
                  Демо-доступ
                </button>
                <button className="border border-gray-300 text-gray-700 py-2 rounded-lg hover:bg-gray-50">
                  Запит кастомізації
                </button>
              </div>
              <button className="w-full border border-green-600 text-green-600 py-2 rounded-lg hover:bg-green-50">
                <MessageCircle className="w-4 h-4 inline mr-2" />
                Зв'язатися з продавцем
              </button>
            </div>
          </div>
        </div>
      </div>

      <div className="bg-white p-6 rounded-lg shadow-md border">
        <h3 className="text-xl font-bold mb-4">Опис проекту</h3>
        <div className="prose max-w-none">
          <h4>Функціонал:</h4>
          <ul>
            <li>Каталог товарів з фільтрацією та пошуком</li>
            <li>Кошик покупок та оформлення замовлень</li>
            <li>Інтеграція з платіжними системами</li>
            <li>Адмін-панель для управління</li>
            <li>Аналітика продажів та відвідувачів</li>
          </ul>

          <h4>Технічні вимоги:</h4>
          <ul>
            <li>Node.js 16+</li>
            <li>MongoDB 4.4+</li>
            <li>React 18+</li>
          </ul>
        </div>
      </div>

      <div className="bg-white p-6 rounded-lg shadow-md border">
        <h3 className="text-xl font-bold mb-4">Відгуки покупців</h3>
        <div className="space-y-4">
          {[1, 2, 3].map(i => (
            <div key={i} className="border-b pb-4">
              <div className="flex items-center space-x-2 mb-2">
                <div className="w-8 h-8 bg-gray-300 rounded-full"></div>
                <span className="font-medium">Користувач {i}</span>
                <div className="flex">
                  {[1, 2, 3, 4, 5].map(star => (
                    <Star key={star} className="w-4 h-4 text-yellow-500" />
                  ))}
                </div>
              </div>
              <p className="text-gray-600">Відмінний проект, швидко запустили в роботу!</p>
            </div>
          ))}
        </div>
      </div>
    </div>
  );

  const AuthPage = () => (
    <div className="max-w-md mx-auto bg-white p-8 rounded-lg shadow-md border">
      <h2 className="text-2xl font-bold text-center mb-6">Вхід / Реєстрація</h2>
      <div className="space-y-4">
        <div>
          <label className="block text-sm font-medium mb-2">Email</label>
          <input 
            type="email" 
            className="w-full border rounded-lg px-3 py-2" 
            placeholder="your@email.com"
          />
        </div>
        <div>
          <label className="block text-sm font-medium mb-2">Пароль</label>
          <input 
            type="password" 
            className="w-full border rounded-lg px-3 py-2" 
            placeholder="••••••••"
          />
        </div>
        <div>
          <label className="block text-sm font-medium mb-2">Роль</label>
          <select className="w-full border rounded-lg px-3 py-2">
            <option value="buyer">Покупець</option>
            <option value="seller">Продавець</option>
          </select>
        </div>
        <button 
          onClick={() => {
            setIsLoggedIn(true);
            setCurrentPage('home');
          }}
          className="w-full bg-blue-600 text-white py-3 rounded-lg font-semibold hover:bg-blue-700"
        >
          Увійти
        </button>
        <div className="text-center">
          <span className="text-gray-500">або</span>
        </div>
        <div className="space-y-2">
          <button className="w-full border border-gray-300 py-2 rounded-lg hover:bg-gray-50">
            Увійти через Google
          </button>
          <button className="w-full border border-gray-300 py-2 rounded-lg hover:bg-gray-50">
            Увійти через GitHub
          </button>
        </div>
        <div className="text-center text-sm">
          <a href="#" className="text-blue-600 hover:underline">Забули пароль?</a>
        </div>
      </div>
    </div>
  );

  const SellerDashboard = () => (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h2 className="text-2xl font-bold">Панель продавця</h2>
        <button 
          onClick={() => setCurrentPage('upload-project')}
          className="bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700"
        >
          <Upload className="w-4 h-4 inline mr-2" />
          Додати проект
        </button>
      </div>

      <div className="grid md:grid-cols-4 gap-6">
        <div className="bg-white p-6 rounded-lg shadow-md border">
          <h3 className="text-lg font-semibold mb-2">Загальні продажі</h3>
          <p className="text-3xl font-bold text-green-600">$2,450</p>
        </div>
        <div className="bg-white p-6 rounded-lg shadow-md border">
          <h3 className="text-lg font-semibold mb-2">Активні проекти</h3>
          <p className="text-3xl font-bold text-blue-600">8</p>
        </div>
        <div className="bg-white p-6 rounded-lg shadow-md border">
          <h3 className="text-lg font-semibold mb-2">Відгуки</h3>
          <p className="text-3xl font-bold text-yellow-600">4.7★</p>
        </div>
        <div className="bg-white p-6 rounded-lg shadow-md border">
          <h3 className="text-lg font-semibold mb-2">Перегляди</h3>
          <p className="text-3xl font-bold text-purple-600">1,240</p>
        </div>
      </div>

      <div className="bg-white rounded-lg shadow-md border">
        <div className="p-6 border-b">
          <h3 className="text-xl font-bold">Мої проекти</h3>
        </div>
        <div className="p-6">
          <div className="space-y-4">
            {projects.map(project => (
              <div key={project.id} className="flex items-center justify-between p-4 border rounded-lg">
                <div className="flex items-center space-x-4">
                  <div className="w-16 h-16 bg-gray-200 rounded"></div>
                  <div>
                    <h4 className="font-semibold">{project.title}</h4>
                    <p className="text-gray-600">{project.category}</p>
                    <div className="flex items-center space-x-2">
                      <Star className="w-4 h-4 text-yellow-500" />
                      <span className="text-sm">{project.rating}</span>
                    </div>
                  </div>
                </div>
                <div className="flex items-center space-x-4">
                  <span className="font-bold text-green-600">{project.price}</span>
                  <div className="flex space-x-2">
                    <BarChart3 className="w-5 h-5 text-gray-500 cursor-pointer hover:text-gray-700" />
                    <Settings className="w-5 h-5 text-gray-500 cursor-pointer hover:text-gray-700" />
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );

  const AdminPanel = () => (
    <div className="space-y-6">
      <h2 className="text-2xl font-bold">Панель адміністратора</h2>

      <div className="grid md:grid-cols-4 gap-6">
        <div className="bg-white p-6 rounded-lg shadow-md border">
          <h3 className="text-lg font-semibold mb-2">Користувачі</h3>
          <p className="text-3xl font-bold text-blue-600">1,234</p>
        </div>
        <div className="bg-white p-6 rounded-lg shadow-md border">
          <h3 className="text-lg font-semibold mb-2">Проекти</h3>
          <p className="text-3xl font-bold text-green-600">456</p>
        </div>
        <div className="bg-white p-6 rounded-lg shadow-md border">
          <h3 className="text-lg font-semibold mb-2">Продажі</h3>
          <p className="text-3xl font-bold text-purple-600">$45,678</p>
        </div>
        <div className="bg-white p-6 rounded-lg shadow-md border">
          <h3 className="text-lg font-semibold mb-2">Скарги</h3>
          <p className="text-3xl font-bold text-red-600">12</p>
        </div>
      </div>

      <div className="grid md:grid-cols-2 gap-6">
        <div className="bg-white rounded-lg shadow-md border">
          <div className="p-6 border-b">
            <h3 className="text-xl font-bold">Модерація контенту</h3>
          </div>
          <div className="p-6">
            <div className="space-y-4">
              {[1, 2, 3].map(i => (
                <div key={i} className="flex items-center justify-between p-3 border rounded">
                  <div>
                    <h4 className="font-medium">Новий проект {i}</h4>
                    <p className="text-sm text-gray-600">Очікує перевірки</p>
                  </div>
                  <div className="flex space-x-2">
                    <button className="bg-green-600 text-white px-3 py-1 rounded text-sm">
                      Схвалити
                    </button>
                    <button className="bg-red-600 text-white px-3 py-1 rounded text-sm">
                      Відхилити
                    </button>
                  </div>
                </div>
              ))}
            </div>
          </div>
        </div>

        <div className="bg-white rounded-lg shadow-md border">
          <div className="p-6 border-b">
            <h3 className="text-xl font-bold">Управління користувачами</h3>
          </div>
          <div className="p-6">
            <div className="space-y-4">
              {[1, 2, 3].map(i => (
                <div key={i} className="flex items-center justify-between p-3 border rounded">
                  <div className="flex items-center space-x-3">
                    <div className="w-8 h-8 bg-gray-300 rounded-full"></div>
                    <div>
                      <h4 className="font-medium">Користувач {i}</h4>
                      <p className="text-sm text-gray-600">Продавець</p>
                    </div>
                  </div>
                  <div className="flex space-x-2">
                    <Shield className="w-5 h-5 text-green-600 cursor-pointer" />
                    <Settings className="w-5 h-5 text-gray-500 cursor-pointer" />
                  </div>
                </div>
              ))}
            </div>
          </div>
        </div>
      </div>
    </div>
  );

  const UploadProjectPage = () => (
    <div className="max-w-4xl mx-auto bg-white p-8 rounded-lg shadow-md border">
      <h2 className="text-2xl font-bold mb-6">Додати новий проект</h2>
      <div className="space-y-6">
        <div className="grid md:grid-cols-2 gap-6">
          <div>
            <label className="block text-sm font-medium mb-2">Назва проекту</label>
            <input 
              type="text" 
              className="w-full border rounded-lg px-3 py-2" 
              placeholder="Назва вашого проекту"
            />
          </div>
          <div>
            <label className="block text-sm font-medium mb-2">Категорія</label>
            <select className="w-full border rounded-lg px-3 py-2">
              <option>Web додатки</option>
              <option>Мобільні додатки</option>
              <option>Дашборди</option>
              <option>API</option>
            </select>
          </div>
        </div>

        <div>
          <label className="block text-sm font-medium mb-2">Опис проекту</label>
          <textarea 
            className="w-full border rounded-lg px-3 py-2 h-32" 
            placeholder="Детальний опис функціоналу..."
          ></textarea>
        </div>

        <div className="grid md:grid-cols-2 gap-6">
          <div>
            <label className="block text-sm font-medium mb-2">Ціна ($)</label>
            <input 
              type="number" 
              className="w-full border rounded-lg px-3 py-2" 
              placeholder="299"
            />
          </div>
          <div>
            <label className="block text-sm font-medium mb-2">Технології</label>
            <input 
              type="text" 
              className="w-full border rounded-lg px-3 py-2" 
              placeholder="React, Node.js, MongoDB"
            />
          </div>
        </div>

        <div>
          <label className="block text-sm font-medium mb-2">Завантажити файли</label>
          <div className="border-2 border-dashed border-gray-300 rounded-lg p-8 text-center">
            <Upload className="w-12 h-12 text-gray-400 mx-auto mb-4" />
            <p className="text-gray-600">Перетягніть файли сюди або клікніть для вибору</p>
            <p className="text-sm text-gray-500 mt-2">Підтримуються: ZIP, RAR, скріншоти, відео</p>
          </div>
        </div>

        <div>
          <label className="block text-sm font-medium mb-2">Демо URL (опціонально)</label>
          <input 
            type="url" 
            className="w-full border rounded-lg px-3 py-2" 
            placeholder="https://demo.yourproject.com"
          />
        </div>

        <div className="flex justify-end space-x-4">
          <button 
            onClick={() => setCurrentPage('my-projects')}
            className="border border-gray-300 text-gray-700 px-6 py-2 rounded-lg hover:bg-gray-50"
          >
            Скасувати
          </button>
          <button 
            onClick={() => setCurrentPage('my-projects')}
            className="bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700"
          >
            Опублікувати проект
          </button>
        </div>
      </div>
    </div>
  );

  const MessagesPage = () => (
    <div className="grid md:grid-cols-3 gap-6 h-96">
      <div className="bg-white rounded-lg shadow-md border">
        <div className="p-4 border-b">
          <h3 className="font-bold">Повідомлення</h3>
        </div>
        <div className="divide-y">
          {[1, 2, 3].map(i => (
            <div key={i} className="p-4 hover:bg-gray-50 cursor-pointer">
              <div className="flex items-center space-x-3">
                <div className="w-10 h-10 bg-gray-300 rounded-full"></div>
                <div className="flex-1">
                  <h4 className="font-medium">Користувач {i}</h4>
                  <p className="text-sm text-gray-600">Питання щодо проекту...</p>
                </div>
                <div className="w-3 h-3 bg-blue-600 rounded-full"></div>
              </div>
            </div>
          ))}
        </div>
      </div>

      <div className="md:col-span-2 bg-white rounded-lg shadow-md border">
        <div className="p-4 border-b flex items-center space-x-3">
          <div className="w-8 h-8 bg-gray-300 rounded-full"></div>
          <h3 className="font-bold">Користувач 1</h3>
        </div>
        <div className="p-4 h-64 overflow-y-auto space-y-4">
          <div className="flex">
            <div className="bg-gray-100 rounded-lg p-3 max-w-xs">
              <p className="text-sm">Привіт! Чи можете надати демо-доступ до вашого проекту?</p>
            </div>
          </div>
          <div className="flex justify-end">
            <div className="bg-blue-600 text-white rounded-lg p-3 max-w-xs">
              <p className="text-sm">Звичайно! Надішлю вам посилання зараз.</p>
            </div>
          </div>
        </div>
        <div className="p-4 border-t">
          <div className="flex space-x-2">
            <input 
              type="text" 
              className="flex-1 border rounded-lg px-3 py-2" 
              placeholder="Введіть повідомлення..."
            />
            <button className="bg-blue-600 text-white px-4 py-2 rounded-lg hover:bg-blue-700">
              Надіслати
            </button>
          </div>
        </div>
      </div>
    </div>
  );

  const WishlistPage = () => (
    <div className="space-y-6">
      <h2 className="text-2xl font-bold">Список бажань</h2>
      <div className="grid md:grid-cols-3 gap-6">
        {projects.map(project => (
          <div key={project.id} className="bg-white rounded-lg shadow-md border hover:shadow-lg transition-shadow">
            <div className="h-48 bg-gray-200 rounded-t-lg flex items-center justify-center relative">
              <span className="text-gray-500">Скріншот проекту</span>
              <button className="absolute top-2 right-2 text-red-500 hover:text-red-700">
                <Heart className="w-6 h-6 fill-current" />
              </button>
            </div>
            <div className="p-4">
              <h4 className="font-bold text-lg mb-2">{project.title}</h4>
              <div className="flex items-center space-x-2 mb-2">
                <Star className="w-4 h-4 text-yellow-500" />
                <span className="text-sm text-gray-600">{project.rating}</span>
              </div>
              <div className="flex justify-between items-center">
                <span className="font-bold text-blue-600">{project.price}</span>
                <div className="flex space-x-2">
                  <button className="bg-blue-600 text-white px-3 py-1 rounded text-sm hover:bg-blue-700">
                    Купити
                  </button>
                  <button className="border border-gray-300 text-gray-700 px-3 py-1 rounded text-sm hover:bg-gray-50">
                    Видалити
                  </button>
                </div>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );

  const PurchaseHistoryPage = () => (
    <div className="space-y-6">
      <h2 className="text-2xl font-bold">Історія покупок</h2>
      <div className="bg-white rounded-lg shadow-md border">
        <div className="p-6">
          <div className="space-y-4">
            {projects.map((project, index) => (
              <div key={index} className="flex items-center justify-between p-4 border rounded-lg">
                <div className="flex items-center space-x-4">
                  <div className="w-16 h-16 bg-gray-200 rounded"></div>
                  <div>
                    <h4 className="font-semibold">{project.title}</h4>
                    <p className="text-gray-600">Придбано: {new Date().toLocaleDateString('uk-UA')}</p>
                    <div className="flex items-center space-x-2">
                      <span className="text-green-600 text-sm">✓ Активна ліцензія</span>
                    </div>
                  </div>
                </div>
                <div className="flex items-center space-x-4">
                  <span className="font-bold">{project.price}</span>
                  <div className="flex space-x-2">
                    <button className="bg-blue-600 text-white px-3 py-1 rounded text-sm hover:bg-blue-700">
                      <Download className="w-4 h-4 inline mr-1" />
                      Завантажити
                    </button>
                    <button className="border border-gray-300 text-gray-700 px-3 py-1 rounded text-sm hover:bg-gray-50">
                      <FileText className="w-4 h-4 inline mr-1" />
                      Документи
                    </button>
                    <button className="border border-green-600 text-green-600 px-3 py-1 rounded text-sm hover:bg-green-50">
                      Підтримка
                    </button>
                  </div>
                </div>
              </div>
            ))}
          </div>
        </div>
      </div>
    </div>
  );

  const renderCurrentPage = () => {
    switch (currentPage) {
      case 'home':
        return <HomePage />;
      case 'catalog':
        return <CatalogPage />;
      case 'project-detail':
        return <ProjectDetailPage />;
      case 'auth':
        return <AuthPage />;
      case 'my-projects':
        return userRole === 'seller' ? <SellerDashboard /> : <HomePage />;
      case 'admin-panel':
        return userRole === 'admin' ? <AdminPanel /> : <HomePage />;
      case 'upload-project':
        return userRole === 'seller' ? <UploadProjectPage /> : <HomePage />;
      case 'messages':
        return <MessagesPage />;
      case 'wishlist':
        return <WishlistPage />;
      case 'purchases':
        return <PurchaseHistoryPage />;
      default:
        return <HomePage />;
    }
  };

  return (
    <div className="min-h-screen bg-gray-50">
      <Header />
      
      <div className="max-w-6xl mx-auto p-6">
        {/* Navigation breadcrumbs */}
        <div className="mb-6">
          <nav className="flex space-x-2 text-sm text-gray-600">
            <button 
              onClick={() => setCurrentPage('home')}
              className="hover:text-blue-600"
            >
              Головна
            </button>
            {currentPage !== 'home' && (
              <>
                <span>/</span>
                <span className="text-gray-900 capitalize">
                  {currentPage.replace('-', ' ')}
                </span>
              </>
            )}
          </nav>
        </div>

        {/* Sidebar for authenticated users */}
        {isLoggedIn && (
          <div className="flex gap-6 mb-6">
            {/* Left sidebar */}
            <div className="w-64 bg-white rounded-lg shadow-md border p-4">
              <div className="space-y-2">
                <button 
                  onClick={() => setCurrentPage('home')}
                  className={`w-full text-left px-3 py-2 rounded hover:bg-gray-100 ${currentPage === 'home' ? 'bg-blue-50 text-blue-600' : ''}`}
                >
                  🏠 Головна
                </button>
                <button 
                  onClick={() => setCurrentPage('catalog')}
                  className={`w-full text-left px-3 py-2 rounded hover:bg-gray-100 ${currentPage === 'catalog' ? 'bg-blue-50 text-blue-600' : ''}`}
                >
                  📁 Каталог
                </button>
                <button 
                  onClick={() => setCurrentPage('wishlist')}
                  className={`w-full text-left px-3 py-2 rounded hover:bg-gray-100 ${currentPage === 'wishlist' ? 'bg-blue-50 text-blue-600' : ''}`}
                >
                  ❤️ Список бажань
                </button>
                <button 
                  onClick={() => setCurrentPage('purchases')}
                  className={`w-full text-left px-3 py-2 rounded hover:bg-gray-100 ${currentPage === 'purchases' ? 'bg-blue-50 text-blue-600' : ''}`}
                >
                  🛒 Мої покупки
                </button>
                <button 
                  onClick={() => setCurrentPage('messages')}
                  className={`w-full text-left px-3 py-2 rounded hover:bg-gray-100 ${currentPage === 'messages' ? 'bg-blue-50 text-blue-600' : ''}`}
                >
                  💬 Повідомлення
                </button>
                
                {userRole === 'seller' && (
                  <>
                    <hr className="my-2" />
                    <button 
                      onClick={() => setCurrentPage('my-projects')}
                      className={`w-full text-left px-3 py-2 rounded hover:bg-gray-100 ${currentPage === 'my-projects' ? 'bg-blue-50 text-blue-600' : ''}`}
                    >
                      📊 Мої проекти
                    </button>
                    <button 
                      onClick={() => setCurrentPage('upload-project')}
                      className={`w-full text-left px-3 py-2 rounded hover:bg-gray-100 ${currentPage === 'upload-project' ? 'bg-blue-50 text-blue-600' : ''}`}
                    >
                      ➕ Додати проект
                    </button>
                  </>
                )}

                {userRole === 'admin' && (
                  <>
                    <hr className="my-2" />
                    <button 
                      onClick={() => setCurrentPage('admin-panel')}
                      className={`w-full text-left px-3 py-2 rounded hover:bg-gray-100 ${currentPage === 'admin-panel' ? 'bg-blue-50 text-blue-600' : ''}`}
                    >
                      🛡️ Панель адміна
                    </button>
                  </>
                )}
              </div>
            </div>

            {/* Main content */}
            <div className="flex-1">
              {renderCurrentPage()}
            </div>
          </div>
        )}

        {/* Full width content for non-authenticated users */}
        {!isLoggedIn && renderCurrentPage()}
      </div>

      {/* Footer */}
      <footer className="bg-gray-800 text-white p-8 mt-12">
        <div className="max-w-6xl mx-auto grid md:grid-cols-4 gap-8">
          <div>
            <h3 className="font-bold text-lg mb-4">DevGallery</h3>
            <p className="text-gray-300">Платформа для демонстрації та продажу програмного забезпечення</p>
          </div>
          <div>
            <h4 className="font-semibold mb-4">Для покупців</h4>
            <ul className="space-y-2 text-gray-300">
              <li><a href="#" className="hover:text-white">Каталог проектів</a></li>
              <li><a href="#" className="hover:text-white">AI-рекомендації</a></li>
              <li><a href="#" className="hover:text-white">Демо-доступ</a></li>
            </ul>
          </div>
          <div>
            <h4 className="font-semibold mb-4">Для продавців</h4>
            <ul className="space-y-2 text-gray-300">
              <li><a href="#" className="hover:text-white">Додати проект</a></li>
              <li><a href="#" className="hover:text-white">Аналітика</a></li>
              <li><a href="#" className="hover:text-white">Підтримка</a></li>
            </ul>
          </div>
          <div>
            <h4 className="font-semibold mb-4">Підтримка</h4>
            <ul className="space-y-2 text-gray-300">
              <li><a href="#" className="hover:text-white">Контакти</a></li>
              <li><a href="#" className="hover:text-white">FAQ</a></li>
              <li><a href="#" className="hover:text-white">Політика</a></li>
            </ul>
          </div>
        </div>
        <div className="max-w-6xl mx-auto mt-8 pt-8 border-t border-gray-700 text-center text-gray-300">
          <p>&copy; 2024 DevGallery. Всі права захищені.</p>
        </div>
      </footer>
    </div>
  );
};

export default DevGalleryWireframe;