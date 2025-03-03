import { ReactNode } from "react";
import { Container } from "react-bootstrap";
import AppNavbar from "../../shared/Navbar";
import Footer from "../../shared/Footer";

interface LayoutProps {
  children: ReactNode;
}

const Layout = ({ children }: LayoutProps) => {
  return (
    <>
      <header>
        <AppNavbar />
      </header>
      <main>
        <Container className="mt-4">{children}</Container>
      </main>

      <Footer />
    </>
  );
};

export default Layout;
